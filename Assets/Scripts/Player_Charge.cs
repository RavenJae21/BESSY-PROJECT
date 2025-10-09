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
        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
            currentChargeTime = 0f;
            Debug.Log("YOUR PRESSING THE BUTTON");
        }
        if (isCharging && Input.GetMouseButtonDown(0))
        {
            currentChargeTime += Time.deltaTime;
            currentChargeTime = Mathf.Min(currentChargeTime, maxChargeTime);
            Debug.Log("HOLD IT!");
        }
        if (Input.GetMouseButtonUp(0))
        {
            isCharging = false;
            currentChargeTime = 0f;
            Debug.Log("YOU LET GO OF THE BUTTON!");
        }
    }
}
