using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*==================== TRIGGER DOOR CONROLLER ================================================
 * Attaches to: Door buttons
 * Attribute(s): None
 * Purpose: Has OnTrigger events that will either open or close a door 
 *          depending on if something is on the button or not. 
 ==============================================================================*/
public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private bool openTrigger = false, closeTrigger = false;
    bool keyOn = false; 


    /*------------------On Trigger Enter---------------------------------------------------
     * Parameters: Collider
     * Purpose: If player or key enters the buttons collider then the door will open
     -------------------------------------------------------------------------------------*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            if (openTrigger)
            {
                keyOn = true; 
                door.Play("DoorOpen", 0, 0.0f);
            }
        }
        else if(other.CompareTag("Player"))
        {
            if (openTrigger && !keyOn)
            {
                door.Play("DoorOpen", 0, 0.0f);
            }
        }
    }

    /*------------------On Trigger Exit---------------------------------------------------
     * Parameters: Collider
     * Purpose: closes the door if player or key exits button. But not if 
     *          player exits button and key doesnt. 
     -------------------------------------------------------------------------------------*/
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            if (openTrigger)
            {
                keyOn = false;
                door.Play("DoorClose", 0, 0.0f);
            }
        }
        else if (other.CompareTag("Player"))
        {
            if(closeTrigger)
            {
                door.Play("DoorClose", 0, 0.0f);
                Destroy(gameObject); 
            }
            else if(openTrigger && !keyOn) 
            {
                door.Play("DoorClose", 0, 0.0f);
            }
        }
    }
}
