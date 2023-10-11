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

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // If a pickup object exists turn gravity on. 
            if(currentObject)
            {
                currentObject.useGravity = true;
                currentObject = null;
                return; 
            }


            // Raycast checks if there's an object to pickup within range 
            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); 

            //Assigns the object a rigidbody and turns off its gravity. 
            if(Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                currentObject = HitInfo.rigidbody; 
                currentObject.useGravity = false;
            }
        }
    }

    //Physics pickup 
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
