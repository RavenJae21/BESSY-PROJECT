using UnityEngine;
using UnityEngine.UI;

public class Player_Charge : MonoBehaviour
{
    public float chargeDamage = 5f;//variable for how much charge damage
    public float currentCharge = 0f;//starting charge
    public float chargeRate = 1f;//how fast it charges up
    public float maxCharge = 100f;//the maximum charge time

    public bool isCharging = false;//boolean for knowing if your charging

    public Slider chargeSlider;

    private Rigidbody rb; //calling rigibody from unity

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Charge();
        UpdateUI();
    }

    public void Charge()
    {
        if (Input.GetMouseButtonDown(0))//if press left click
        {
            currentCharge = 0f;
            isCharging = true;
            Debug.Log("Your pressing the button!");
        }
        if (isCharging && Input.GetMouseButton(0))
        {
            currentCharge += chargeRate * Time.deltaTime;//smoothly charges up
            currentCharge = Mathf.Clamp(currentCharge, 0f, maxCharge);//will not exceed max charge
            UpdateUI();
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentCharge = 0f;
            isCharging = false;
            Debug.Log("You let go of the button!");
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        if (chargeSlider != null)
        {
            chargeSlider.value = currentCharge / maxCharge;
        }
    }
}
