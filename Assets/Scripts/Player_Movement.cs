using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 10f;//variable for move speed
    public float jumpForce = 4f;//variable for how high to jump
    public float chargeDamage = 5f;//variable for how much charge damage
    public float camSpeed;
    public  Transform Cam;

    public bool isGrounded = false;//bool for if the player is touching the ground

    private Rigidbody rb; //calling rigibody from unity

    public CharacterController controller;




    void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting rigibody component
        controller = GetComponent<CharacterController>();//getting character controller
    }

    void Update()
    {
        PlayerMove();
        PlayerJump();
        //CameraMovement();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
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

    /*public void CameraMovement()
    {
        float Horizontal = Input.GetAxis("Horizontal") * camSpeed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * camSpeed * Time.deltaTime;

        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = 0f;



        controller.Move(Movement);

        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<Camera>().sensivity * Time.deltaTime);

            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }
    }*/
}


