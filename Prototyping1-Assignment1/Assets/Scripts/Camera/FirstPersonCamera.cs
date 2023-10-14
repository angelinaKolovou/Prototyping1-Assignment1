using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*==================== FIRST PERSON CAMERA =====================================
 * Attaches to: Main Camera
 * Attribute(s): xSensitivity(), ySensitivity(), orientation(Player/Orientation 
 * Purpose: Rotates camera and player orientation according to mouse input. 
 ==============================================================================*/
public class FirstPersonCamera : MonoBehaviour
{
    public Transform orientation;

    [SerializeField] static float xSensitivity, ySensitivity;
    float xRotation, yRotation; 

    void Start()
    {
        //Lock cursor to screen and hide it. 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Start rotation speed
        SetRotationSpeed(200f, 200f); 
    }

    void Update()
    {
        // Get mouse input.
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity; 
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        //Needed for Unity to handle the rotation. 
        yRotation += mouseX;
        xRotation -= mouseY; 

        //Stop player from rotating more than 90 degrees. 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotation for camera on the x axis
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //Rotation for player orientation on the Y axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); 

    }


    /*------------------SET ROTATION SPEED--------------------------------------------------
     * Parameters: float for camra rotation speed 
     * Purpose: Used by state script to change camera rotation speed. 
     ---------------------------------------------------------------------------------*/
    static public void SetRotationSpeed(float xSens, float ySens)
    {
        xSensitivity = xSens;
        ySensitivity = ySens;
    }
}
