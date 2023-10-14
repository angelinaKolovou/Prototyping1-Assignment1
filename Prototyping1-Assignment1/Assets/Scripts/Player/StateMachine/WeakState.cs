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

    /*------------------ENTER STATE----------------------------------------------
     * Parameters: player
     * Purpose: Sets movement speed and camera rotation speed
     ---------------------------------------------------------------------------*/
    public override void EnterState(PlayerStateManager player) 
    {
        movSpeed = 2f;
        rotSpeed = 100f;

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);
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
                movSpeed = movSpeed + 0.3f;
                rotSpeed = rotSpeed + 20f;

                oldNumOfPowerUps = newNumOfPowerUps;
            }

           /*
            if (PickupObjects.carryingObject)
            {
                movSpeed = movSpeed - 0.5f;
                rotSpeed = rotSpeed - 20f;
            }
           */

        }
        else if (PlayerStats.numOfPowerups == 9)
        {
            player.SwitchState(player.godModeState); 
        }

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);
    }

}
