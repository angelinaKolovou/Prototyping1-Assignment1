using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*==================== POWER UP ================================================
 * Attaches to: Powerup
 * Attribute(s): powerUpAmount()
 * Purpose: Handles on trigger event to call function in PlayerStats
 *          that increases power and health
 ==============================================================================*/
public class Powerup : MonoBehaviour
{
    public float powerUpAmount;

    /*------------------ON TRIGGER ENTER---------------------------------------------------
     * Parameters: Collider
     * Purpose: Trigger event when player gets into contact with trigger object.
     -------------------------------------------------------------------------------------*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        { 
            var playerStats = other.transform.root.GetComponentInChildren<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.PowerUp(powerUpAmount);

            }
            else
                Debug.Log("No playerstats found"); 
            Destroy(gameObject);
        }
    }
}
