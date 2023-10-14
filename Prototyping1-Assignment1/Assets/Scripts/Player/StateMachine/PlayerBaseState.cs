using System.Security.Cryptography;
using UnityEngine;
/*==================== BASE STATE ============================================
 * Attaches to: 
 * Attribute(s): 
 * Purpose: Abstract State
 ==============================================================================*/
public abstract class PlayerBaseState 
{
    public abstract void EnterState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
}
