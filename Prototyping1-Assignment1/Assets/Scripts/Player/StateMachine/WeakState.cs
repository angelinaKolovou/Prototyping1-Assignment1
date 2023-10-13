using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakState : PlayerBaseState
{
    PlayerStats playerStats;
    PlayerMovement1 playerMovement;
    FirstPersonCamera playerCamera;
    PickupObjects pickupObjects;
    [SerializeField] float movSpeed, rotSpeed;



    /*------------------GROW PLAYER---------------------------------------------------
     * Parameters: None
     * Purpose: Set movement speed and camera rotation to low
     *          sliglty uncomfortable number. 
     *          Slow down more when carrying something 
     -----------------------------------------------------------------------------*/

    /*------------------ENTER STATE----------------------------------------------
     * Parameters: player
     * Purpose: Sets movement speed and camera rotation speed
     ---------------------------------------------------------------------------*/
    public override void EnterState(PlayerStateManager player) 
    {
        movSpeed = 2f;
        rotSpeed = 100f;

        playerMovement.SetMovementSpeed(movSpeed);
        playerCamera.SetRotationSpeed(rotSpeed, rotSpeed);
    }

    /*------------------UPDATE STATE---------------------------------------------
     * Parameters: player
     * Purpose: Changes speed if player is carrying something. 
     *          Switches state when powerups reach 9.
     ---------------------------------------------------------------------------*/
    public override void UpdateState(PlayerStateManager player) 
    {
        //If the player is carrying something then slow down rotation and speed
        if (pickupObjects.carryingObject)
        {
            movSpeed = movSpeed - 0.5f;
            rotSpeed = rotSpeed - 50f;

            playerMovement.SetMovementSpeed(movSpeed);
            playerCamera.SetRotationSpeed(rotSpeed, rotSpeed);
        }
        else
        {
            movSpeed = 2f;
            rotSpeed = 100f;

            playerMovement.SetMovementSpeed(movSpeed);
            playerCamera.SetRotationSpeed(rotSpeed, rotSpeed);

        }

        //If the player collects 9 powerups 
        if (playerStats.numOfPowerups == 9)
        {
            player.SwitchState(player.godModeState); 
        }
    }

}
