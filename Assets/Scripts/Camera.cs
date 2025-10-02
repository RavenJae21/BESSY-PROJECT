using UnityEngine;

public class Camera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float cameraSensitivity = 2f; //For camera rotation

    private CharacterController characterController;
    private Transform cameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = Vector3.zero;
        if (verticalInput != 0)
        {
            moveDirection += cameraTransform.forward * verticalInput;
        }
        if (horizontalInput != 0)
        {
            moveDirection += cameraTransform.right * horizontalInput;
        }

        // Normalize the movement direction
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Apply movement
        moveDirection *= moveSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
