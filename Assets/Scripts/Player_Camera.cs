using UnityEngine;

public class Player_Camera : MonoBehaviour
{

    public float mouseSensitivityX = 2.0f; // How much the camera rotates horizontally
    public float mouseSensitivityY = 2.0f; // How much the camera rotates vertically
    public float _xRotation = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraLook();
    }
    
    public void CameraLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;

        // Apply the input to camera rotation
        _xRotation += mouseX;

        // Rotate the camera
        transform.rotation = Quaternion.Euler(0, _xRotation, 0);
    }
}
