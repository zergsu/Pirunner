using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    [Header("Sounds")]
    public AudioClip jumpSound;


    [Header("Movement")]
    public float moveSpeed;
    public bool sprinting;
    public bool moving;
    public bool onMovingPlatform;
    public bool onMud;
    public float groundDrag;




    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;



    [Header("BunnyHopping")]
    public float maxSpeed;
    public float maxSpeedCap;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Constants")]
    const string VERTICAL_INPUT = "Vertical";
    const string HORIZONTAL_INPUT = "Horizontal";

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    
    [Header("Inputs")]
    float horizontalInput;
    float verticalInput;

    [Header("Refs")]
    public Transform orientation;
    public Rigidbody rb;


    Vector3 moveDirection;

    

    private void Start()
    {
        rb.freezeRotation = true;
        readyToJump = true;
        onMovingPlatform = false;
        maxSpeed = moveSpeed;
        onMud = false;
    }

    private void Update()
    {
        GroundCheck();
        PlayerInput();
        SpeedControl();

        
        if (grounded)
		{
            rb.drag = groundDrag;  // handle drag

            if (horizontalInput == 0 && verticalInput == 0) 
			{
                rb.velocity = new Vector3(0, 0, 0);
                transform.position = transform.position;
            }
        }
            
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput()
    {
        if(!GameManager.instance.playerDied)
		{
            if (grounded)
            {
                horizontalInput = Input.GetAxisRaw(HORIZONTAL_INPUT);
            }
            else horizontalInput = Input.GetAxisRaw(HORIZONTAL_INPUT) * 0.1f;

            verticalInput = Input.GetAxisRaw(VERTICAL_INPUT);
        }

        
        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded) // when to jump
        {
            readyToJump = false;

            if(!onMud)
			{
                Jump();
            }

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        sprinting = Input.GetKey(sprintKey);
        moving = (horizontalInput != 0 || verticalInput != 0);
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; // calculate movement direction

        if (grounded)
            if (sprinting)
                rb.AddForce(moveDirection.normalized * (moveSpeed * 3.5f) * 10f, ForceMode.Force);
            else
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded && !sprinting)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        else if (!grounded && sprinting)
            rb.AddForce(moveDirection.normalized * (moveSpeed * 3.5f) * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity
        if (flatVel.magnitude > maxSpeed) // checks of the velocity is higher then the moveSpeed
        {
            Vector3 limitedVel = flatVel.normalized * maxSpeed; // creates limited velocity
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);// defines the rb velocity based on limited velocity
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        if (maxSpeed < maxSpeedCap && verticalInput != 0)  
		{
            maxSpeed += 2;
		}
        //SoundManager.instance.PlaySound(jumpSound);
    }


    private void ResetJump()
    {
        readyToJump = true;
    }


    IEnumerator CanBunnyHop()
	{
        yield return new WaitForSeconds(0.3f);
            if(grounded)
		{
            maxSpeed = moveSpeed;
		}
            
	}

    private void GroundCheck()
	{
        if (Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround))
        {
            grounded = true;
            StartCoroutine(CanBunnyHop());// resets the max speed for bunny hopping
        }
        else { grounded = false; }
    }


    public void OnJumper(float jumpForce)
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

}