using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*==================== STATE MANAGER ============================================
 * Attaches to: Player (parent)
 * Attribute(s): 
 * Purpose: Context for state machine 
 ==============================================================================*/
public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public WeakState weakState = new WeakState();
    public GodModeState godModeState = new GodModeState();
    public ShutDownState shutDonwState = new ShutDownState(); 

    void Start()
    {
        currentState = weakState;

        currentState.EnterState(this); 
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this); 
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
