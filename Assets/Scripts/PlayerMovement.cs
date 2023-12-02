using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public Transform gravityRay;

    public bool readyToJump;

    [Header("keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("GroundCheck")]
    private float playerHeight;
    public LayerMask groundCheck;
    bool isGrounded;


    public Transform orientation;
    public Transform straightAhead;


    float hozInput;
    float vertInput;
    Quaternion gravityDirection;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        playerHeight = GetComponentInChildren<CapsuleCollider>().height;
    }


	private void FixedUpdate() {
        MovePlayer();
	}

	// Update is called once per frame
	void Update() {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundCheck);

        MyInput();
        CheckGravity();
        SpeedControl();

        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0f;
    }

    private void MyInput() {
        hozInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Q)) {
            gravityDirection = Camera.main.transform.rotation;
		}


        if (Input.GetKey(jumpKey) && readyToJump && isGrounded) {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
		}
    }

    private void MovePlayer() {
        moveDirection = orientation.forward * vertInput + orientation.right * hozInput;
            
        if (isGrounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else if (!isGrounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
		}
	}

    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed) {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
		}
	}

    private void CheckGravity() {
        // Extract plane to change gravity to based off quaternion

        // Change physics.gravity to correct plane


        // Rotate player object (which should rotate camera object as well)

    }

    public void Jump() {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}

    private void ResetJump() {
        readyToJump = true;
	}
}
