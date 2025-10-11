using UnityEngine;

public class Player_Charge : MonoBehaviour
{
    public float chargeDamage = 5f;//variable for how much charge damage
    public float currentCharge = 0f;//starting charge
    public float chargeRate = 1f;//how fast it charges up
    public float maxCharge = 5f;//the maximum charge time

    public bool isCharging = false;//boolean for knowing if your charging

    private Rigidbody rb; //calling rigibody from unity

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Charge()
    {
        if (Input.GetMouseButtonDown(0))//if press left click
        {
            currentCharge = 0f;
            isCharging = true;
            Debug.Log("Your pressing the button!");
        }
        if (isCharging)
        {
            currentCharge += chargeRate * Time.deltaTime;//smoothly charges up
            currentCharge = Mathf.Min(currentCharge, maxCharge);//will not exceed max charge
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentCharge = 0f;
            isCharging = false;
            Debug.Log("You let go of the button!");
        }
    }
}
