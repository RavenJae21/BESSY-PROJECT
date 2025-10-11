using UnityEngine;

public class Player_Cam : MonoBehaviour
{
    public Transform target;      // Player
    public Vector3 offset = new Vector3(0f, 2f, -4f);
    public float sensitivity = 100f;
    public float rotationSmoothTime = 0.12f;

    float yaw;   // Horizontal rotation
    float pitch; // Vertical rotation
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Mouse input
        yaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -40f, 70f);

        // Smooth rotation
        Vector3 targetRotation = new Vector3(pitch, yaw);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation;

        // Follow target
        transform.position = target.position + transform.rotation * offset;
    }
}
