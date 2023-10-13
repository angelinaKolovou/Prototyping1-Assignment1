using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDownState : PlayerBaseState

{
    PlayerStats playerStats;

    PlayerMovement1 playerMovement;
    FirstPersonCamera playerCamera;

    [SerializeField] float movSpeed, rotSpeed;
    int oldNumOfPowerups;

    /*------------------ENTER STATE----------------------------------------------
     * Parameters: player
     * Purpose: Sets movement speed and camera rotation speed
     ---------------------------------------------------------------------------*/
    public override void EnterState(PlayerStateManager player)
    {
        movSpeed = 7f;
        rotSpeed = 200f;

        playerMovement.SetMovementSpeed(movSpeed);
        playerCamera.SetRotationSpeed(rotSpeed, rotSpeed);
    }


    /*------------------UPDATE STATE---------------------------------------------
     * Parameters: player
     * Purpose: Everytime the player picks up a power up
     *          the movement and camera rotation speed slow down. 
     ---------------------------------------------------------------------------*/
    public override void UpdateState(PlayerStateManager player)
    {
        int newNumOfPowerups = playerStats.numOfPowerups;

        if (newNumOfPowerups > oldNumOfPowerups)
        {
            movSpeed = movSpeed - 0.5f;
            rotSpeed = rotSpeed - 14f;

            playerMovement.SetMovementSpeed(movSpeed);
            playerCamera.SetRotationSpeed(rotSpeed, rotSpeed);

            oldNumOfPowerups = newNumOfPowerups;
        }
    }
}
