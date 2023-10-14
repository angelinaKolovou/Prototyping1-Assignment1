using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*==================== GOD MODE STATE ============================================
 * Attaches to: None
 * Attribute(s): Private 
 * Purpose: Handles player movement during God Mode state.  
 ==============================================================================*/
public class GodModeState : PlayerBaseState
{
    [SerializeField] float movSpeed, rotSpeed;

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
     * Purpose: Switches state when powerups reach 13
     ---------------------------------------------------------------------------*/
    public override void UpdateState(PlayerStateManager player)
    {
        if(PlayerStats.numOfPowerups == 13)
        {
            player.SwitchState(player.shutDonwState);
        }
    }
}
