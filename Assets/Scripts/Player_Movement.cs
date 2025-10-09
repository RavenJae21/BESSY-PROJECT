using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 10f;//variable for move speed
    public float jumpForce = 4f;//variable for how high to jump
    
    public bool isGrounded = false;//bool for if the player is touching the ground

    private Rigidbody rb; //calling rigibody from unity

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting rigibody component
    }

    void Update()
    {
        PlayerMove();
        PlayerJump();
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

}


