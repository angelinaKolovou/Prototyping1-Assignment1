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

    static public bool carryingObject; 
    [SerializeField] bool canLift;
    void Start()
    {
        carryingObject = false;
    }

    /*------------------UPDATE---------------------------------------------------
     * Parameters: None
     * Purpose: On LMB it checks if the player is holding an object by 
     *          using a RayCast. if the player is holding an object 
     *          they player will drop it and the object will have gravity turn
     *          back on. if not, the player will pick up the object.
     *          Can only run lift code if player is strong enough
     ---------------------------------------------------------------------------*/
    void Update()
    {
        if(CheckIfCanLift())
        {
            Debug.Log("Can Lift " + canLift); 
            KeyCube.ChangeColour(canLift);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Player releases object. gravity is turned on. 
                if (currentObject)
                {
                    currentObject.useGravity = true;
                    currentObject = null;
                    carryingObject = false;
                    return;
                }

                //Holds object in the same rotation as camera 
                Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

                //Player picks up object. gravity is turned off
                if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
                {
                    currentObject = HitInfo.rigidbody;
                    currentObject.useGravity = false;
                    carryingObject = true;

                }

                canLift = false;

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

    /*------------------FIXED UPDATE---------------------------------------------------
     * Parameters: Bool CanLift
     * Purpose: Makes sure the player has picked up all the powerups 
     *          before it lets them pick up the key
     ---------------------------------------------------------------------------------*/
    private bool CheckIfCanLift()
    {
        float num = PlayerStats.numOfPowerups;

        if (num == 0 || num == 6 || num == 9)
        {
            canLift = true;
        }
        else
        {
            canLift = false;
        }
        return canLift; 

    }
}
