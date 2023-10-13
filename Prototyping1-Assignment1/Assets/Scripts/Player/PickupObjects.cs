using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*==================== PickupObjects =====================================
 * Attaches to: Player (parent)
 * Attribute(s): Layer(canPickup), PlayerCamera(CameraHolder/Main camera)
 *               PickupPoint(Player/PickupPoint)
 * Purpose: Enables the player to pick up certain objects
 ==============================================================================*/
public class PickupObjects : MonoBehaviour
{
    [SerializeField] LayerMask PickupMask;
    [SerializeField] Camera PlayerCamera;
    [SerializeField] Transform PickupPoint;
    [Space]
    [SerializeField] float PickupRange;
    Rigidbody currentObject;

    public bool carryingObject;
    void Start()
    {
        carryingObject = false;
    }

    /*------------------UPDATE---------------------------------------------------
     * Parameters: None
     * Purpose: On LMB it checks if a pickupable object exists by using a RayCast.
     *          Gives the object a rigidbody and turns off its gravity. 
     ---------------------------------------------------------------------------*/
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Player releases object. gravity gets turned on. 
            if(currentObject)
            {
                currentObject.useGravity = true;
                currentObject = null;
                carryingObject = false;
                return; 
            }

            // Raycast checks if there's an object to pickup within range 
            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); 

            //Player picks up object. gravity is turned off
            if(Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                currentObject = HitInfo.rigidbody; 
                currentObject.useGravity = false;
                carryingObject = true;

            }
        }
    }

    /*------------------FIXED UPDATE---------------------------------------------------
     * Parameters: none
     * Purpose: Handles the physics of an object that's being picked up.
     ---------------------------------------------------------------------------------*/
    private void FixedUpdate()
    {
        //If pickup exist. 
        if(currentObject)
        {

            Vector3 DirectionToPoint = PickupPoint.position - currentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            currentObject.velocity = DirectionToPoint * 12f * DistanceToPoint; 
        }
    }
}
