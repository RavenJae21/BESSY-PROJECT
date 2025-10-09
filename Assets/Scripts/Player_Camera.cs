using System.Numerics;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public Transform target;      // Player

    public UnityEngine.Vector3 offset = new UnityEngine.Vector3(0f, 2f, -4f);
    
    public float sensitivity = 100f;
    public float rotationSmoothTime = 0.12f;

    float yaw;   // Horizontal rotation
    float pitch; // Vertical rotation

    UnityEngine.Vector3 rotationSmoothVelocity;
    UnityEngine.Vector3 currentRotation;

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
        UnityEngine.Vector3 targetRotation = new UnityEngine.Vector3(pitch, yaw);
        currentRotation = UnityEngine.Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation;

        // Follow target
        transform.position = target.position + transform.rotation * offset;
    }
}
