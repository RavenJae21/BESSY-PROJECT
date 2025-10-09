using UnityEngine;

public class Player_Charge : MonoBehaviour
{

    public float maxChargeTime = 5f; // Maximum time to charge
    public float currentChargeTime = 0f; // Current charge duration
    public float minChargeThreshold = 0.1f; // Minimum time held for a "charged" action

    public bool isCharging = false; // Is the ability currently charging?

    private Rigidbody rb;//calling character rigibody

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Charge();
    }

    public void Charge()
    {
        if (Input.GetButtonDown("Shift"))
        {
            isCharging = true;
            currentChargeTime = 0f;
            Debug.Log("YOUR HOLDING THE BUTTON DOWN!");
        }
        if (isCharging && Input.GetButtonDown("Shift"))
        {
            currentChargeTime += Time.deltaTime;
            currentChargeTime = Mathf.Min(currentChargeTime, maxChargeTime);
        }
        if (Input.GetButtonUp("Shift"))
        {
            isCharging = false;
            currentChargeTime = 0f;
            Debug.Log("YOU LET GO OF THE BUTTON!");
        }
    }
}
