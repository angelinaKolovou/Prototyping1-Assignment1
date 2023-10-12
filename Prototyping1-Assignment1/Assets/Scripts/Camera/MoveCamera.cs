using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*==================== FIRST PERSON CAMERA =====================================
 * Attaches to: Camera Holder
 * Attribute(s): cameraPosition(Player/Camera Position)  
 * Purpose: Makes sure the camera is always attached to and moving with 
 *          the player.
 ==============================================================================*/
public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition; 

    void Update()
    {
        //Give camera position objects lovation to camera holder.
        transform.position = cameraPosition.position; 
    }
}
