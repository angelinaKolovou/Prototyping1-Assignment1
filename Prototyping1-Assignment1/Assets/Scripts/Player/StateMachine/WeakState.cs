using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*==================== WEAK STATE ============================================
 * Attaches to: None
 * Attribute(s): Private 
 * Purpose: Handles player movement during weak state.  
 ==============================================================================*/
public class WeakState : PlayerBaseState
{
    [SerializeField] float movSpeed, rotSpeed;
    int oldNumOfPowerUps, newNumOfPowerUps;
    bool hasSlowed; 


    /*------------------ENTER STATE----------------------------------------------
     * Parameters: player
     * Purpose: Sets movement speed and camera rotation speed
     ---------------------------------------------------------------------------*/
    public override void EnterState(PlayerStateManager player) 
    {
        movSpeed = 3f;
        rotSpeed = 100f;

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);

        hasSlowed = false; 
    }

    /*------------------UPDATE STATE---------------------------------------------
     * Parameters: player
     * Purpose: Changes speed if player is carrying something. 
     *          Switches state when powerups reach 9.
     ---------------------------------------------------------------------------*/
    public override void UpdateState(PlayerStateManager player) 
    {
        newNumOfPowerUps = PlayerStats.numOfPowerups;

        if (newNumOfPowerUps < 9)
        {
           if(newNumOfPowerUps > oldNumOfPowerUps)
            {
                AddSpeed(); 
                oldNumOfPowerUps = newNumOfPowerUps;
            }

            if (PickupObjects.carryingObject && !hasSlowed)
            {
                SlowDownPlayer(); 
            }
            else if(PickupObjects.carryingObject == false && hasSlowed)
            {
                RestoreSpeed(); 
            }


        }
        else if (PlayerStats.numOfPowerups == 9)
        {
            player.SwitchState(player.godModeState); 
        }
    }

    public void AddSpeed()
    {
        movSpeed = movSpeed + 0.3f;
        rotSpeed = rotSpeed + 20f;

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);
    }
    public void SlowDownPlayer()
    {
        movSpeed = movSpeed - 1f; 
        rotSpeed = rotSpeed - 20f;

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);

        hasSlowed = true;
    }

    public void RestoreSpeed()
    {
        movSpeed = movSpeed + 1f;
        rotSpeed = rotSpeed + 20f;

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);

        hasSlowed = false;
    }

}
