using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*==================== FIRST PERSON CAMERA =====================================
 * Attaches to: Player (parent)
 * Attribute(s): movementSpeed(), orientation(player.orientation) 
 * Purpose: Handles player movement according to input 
 ==============================================================================*/
public class PlayerMovement1 : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed, groundDrag; 

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask isGround; 
    bool onGround; 

    public Transform orientation;

    float horizontalInput, verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        //Ground check
        onGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGround); 

        //Apply drag when player is on the ground.
        if (onGround)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        PlayerInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //For god mode
        rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        // Get flat velocity of rigidbody on x and z axis
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); 

        //Limit velocity if needed
        if(flatVelocity.magnitude > movementSpeed)
        {
            Vector3 limitVelocity = flatVelocity.normalized * movementSpeed;

            //Plly limited velocity to rigidbody
            rb.velocity = new Vector3(limitVelocity.x, rb.velocity.y, limitVelocity.z); 
        }
    }
}
