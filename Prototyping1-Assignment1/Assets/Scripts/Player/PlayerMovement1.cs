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
    public Transform orientation;

    float horizontalInput, verticalInput;
    Vector3 moveDirection;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask isGround; 

    bool onGround; 

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

        //Functions
        PlayerInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    /*------------------PLAYER INPUT---------------------------------------------------
     * Parameters: none
     * Purpose: Gets player input.
     ---------------------------------------------------------------------------------*/
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    /*------------------MOVE PLAYER----------------------------------------------------
     * Parameters: none
     * Purpose: Adds force to player movement so the player can move
     *          on the x and z axel. 
     ---------------------------------------------------------------------------------*/
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //For god mode
        rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
    }

    /*------------------SPEED CONTROL--------------------------------------------------
     * Parameters: none
     * Purpose: Makes sure the player doesn't exeed speed limit 
     ---------------------------------------------------------------------------------*/
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
