using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*==================== SHUT DOWN STATE ============================================
 * Attaches to: None
 * Attribute(s): Private 
 * Purpose: Handles player movement during Shut Down state.  
 ==============================================================================*/
public class ShutDownState : PlayerBaseState
{
    [SerializeField] float movSpeed, rotSpeed;
    int oldNumOfPowerUps, newNumOfPowerUps;

    /*------------------ENTER STATE----------------------------------------------
     * Parameters: player
     * Purpose: Sets movement speed and camera rotation speed
     ---------------------------------------------------------------------------*/
    public override void EnterState(PlayerStateManager player)
    {
        movSpeed = 7f;
        rotSpeed = 200f;

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);
    }


    /*------------------UPDATE STATE---------------------------------------------
     * Parameters: player
     * Purpose: Everytime the player picks up a power up
     *          the movement and camera rotation speed slow down. 
     ---------------------------------------------------------------------------*/
    public override void UpdateState(PlayerStateManager player)
    {

        if (newNumOfPowerUps > oldNumOfPowerUps)
        {
            movSpeed = movSpeed - 0.5f;
            rotSpeed = rotSpeed - 14f;

            oldNumOfPowerUps = newNumOfPowerUps;
        }

        PlayerMovement1.SetMovementSpeed(movSpeed);
        FirstPersonCamera.SetRotationSpeed(rotSpeed, rotSpeed);

        if (newNumOfPowerUps < 1 ) 
        {
            Debug.Log("Game Over"); 
        }
    }
}
