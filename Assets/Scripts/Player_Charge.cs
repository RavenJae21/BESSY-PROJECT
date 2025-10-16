using UnityEngine;
using UnityEngine.UI;

public class Player_Charge : MonoBehaviour
{
    public float chargeDamage = 5f;//variable for how much charge damage
    public float currentCharge = 0f;//starting charge
    public float chargeRate = 1f;//how fast it charges up
    public float maxCharge = 100f;//the maximum charge time

    public bool isCharging = false;//boolean for knowing if your charging

    //audio clips
    public AudioSource audioSource;
    public AudioClip mooSound;

    public Slider chargeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        }
        if (isCharging && Input.GetMouseButton(0))
        {
            currentCharge += chargeRate * Time.deltaTime;//smoothly charges up
            currentCharge = Mathf.Clamp(currentCharge, 0f, maxCharge);//will not exceed max charge
            UpdateUI();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(currentCharge >= maxCharge)
            {
                if (audioSource != null && mooSound != null)
                {
                    audioSource.PlayOneShot(mooSound);
                }
            }
            currentCharge = 0f;
            isCharging = false;
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
