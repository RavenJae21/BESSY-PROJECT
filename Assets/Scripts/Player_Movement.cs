using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 10f;//variable for move speed
    public float jumpForce = 4f;//variable for how high to jump

    public Transform cameraTransform;

    public bool isGrounded = false;//bool for if the player is touching the ground

    private Rigidbody rb; //calling rigibody from unity

    private CharacterController controller;



    void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting rigibody component
        controller = GetComponent<CharacterController>();//getting character controller
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    public void PlayerMove()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, yValue, zValue);
    }

    public void PlayerJump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void Camera()
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
    }
}


