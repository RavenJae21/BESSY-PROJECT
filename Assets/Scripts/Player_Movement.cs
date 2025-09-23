using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody rb; //calling rigibody from unity

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting rigibody component
    }

    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizantal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, yValue, zValue);

    }
}
