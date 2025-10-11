using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    //move and jump settings
    public float moveSpeed = 10f;//variable for move speed
    public float jumpHeight = 4f;//variable for how high to jump
    public float gravity = -3f;

    //camera reference
    public Transform cameraTransform;

    public Vector3 velocity;
    public bool isGrounded = false;//bool for if the player is touching the ground
    private CharacterController controller;

    //private Rigidbody rb; //calling rigibody from unity


    void Start()
    {
        //rb = GetComponent<Rigidbody>(); //getting rigibody component
        controller = GetComponent<CharacterController>();//getting character controller
    }

    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
        }
    }*/

    void Update()
    {
        PlayerMove();
        PlayerJump();
        //Camera();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectible"))
        {
            Destroy(hit.gameObject);
        }
    }

    public void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Rotate the player to face the camera direction while moving
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

            // Move the player forward relative to camera
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }
        /*float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, yValue, zValue);*/
    }

    public void PlayerJump()
    {
        // Check if on ground
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Keeps player grounded
        }

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical motion
        controller.Move(velocity * Time.deltaTime);
        
        /*if (Input.GetButton("Jump") && isGrounded)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }*/
    }

    /*public void Camera()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Rotate the player to face the camera direction while moving
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

            // Move the player forward
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }*/
}


