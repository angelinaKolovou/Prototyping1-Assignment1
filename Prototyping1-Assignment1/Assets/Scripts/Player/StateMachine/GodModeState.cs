using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModeState : PlayerBaseState
{
    PlayerStats playerStats;

    PlayerMovement1 playerMovement;
    FirstPersonCamera playerCamera;

    [SerializeField] float movSpeed, rotSpeed;

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
     * Purpose: Switches state when powerups reach 13
     ---------------------------------------------------------------------------*/
    public override void UpdateState(PlayerStateManager player)
    {
        if(playerStats.numOfPowerups == 13)
        {
            player.SwitchState(player.shutDonwState);
        }
    }
}