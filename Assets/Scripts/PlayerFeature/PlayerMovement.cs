using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool debugMode;
    private List<string> errorMessages;
    private PlayerControl camera;
    private Vector3 targetAngle;


    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public Transform cameraForward;
    private Vector3 gravityDirection;
    private bool qKeyPressed = false; // Variable to track if Q key was pressed

    public bool readyToJump;

    [Header("keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("GroundCheck")]
    private float playerHeight;
    public LayerMask groundCheck;
    public bool isGrounded;

    public Transform orientation;

    float hozInput;
    float vertInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        playerHeight = GetComponentInChildren<CapsuleCollider>().height;
        camera = GameObject.FindWithTag("MainCamera").GetComponent<PlayerControl>();
        //playerDebug = GameObject.FindWithTag("PlayerDebug").GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Update() {
        isGrounded = Physics.Raycast(transform.position, -transform.up, playerHeight * 0.5f + 0.2f, groundCheck);
        Debug.DrawRay(transform.position, cameraForward.forward * 10f, Color.green);

        MyInput();
        SpeedControl();

		if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0f;
    }


    private void FixedUpdate() {
        MovePlayer();
	}

    private void MyInput() {
        hozInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Q) && !qKeyPressed) {
            qKeyPressed = true;
            CheckGravity();
            Invoke(nameof(ResetGravityPower), 2);
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
            // If object is falling in x or z apply artificial force
            if (gravityDirection.y == 0) {
                moveDirection += gravityDirection;
            }

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed) {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void CheckGravity() {
        Ray gravityRay = new Ray(transform.position, cameraForward.forward);
        RaycastHit collidedPlane;

        if (Physics.Raycast(gravityRay, out collidedPlane, 50.0f, groundCheck)) {
            Physics.gravity = collidedPlane.normal * -9.81f;

            gravityDirection = collidedPlane.normal * -9.81f;

            Quaternion originalRotation = transform.rotation;
            Vector3 playerUp = originalRotation * Vector3.up;

            Quaternion rotationDifference = Quaternion.FromToRotation(collidedPlane.normal, playerUp);


            StartCoroutine(DelayedRotation(Quaternion.Euler(-rotationDifference.eulerAngles)));

        }


    }

    IEnumerator DelayedRotation(Quaternion targetRotation) {
        float duration = 0.5f; // Adjust as needed
        Quaternion initialRotation = transform.rotation;
        Quaternion finalRotation = targetRotation * initialRotation;

        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            float t = elapsedTime / duration;
            transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        transform.rotation = finalRotation; // Ensure final rotation is exact
    }

    public void Jump() {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() {
        readyToJump = true;
    }

    private void ResetGravityPower() {
        qKeyPressed = false;
    }
}
