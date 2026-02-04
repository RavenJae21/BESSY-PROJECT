using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player_Charge : MonoBehaviour
{
    //lunge dist, spd
    public float lungeDistance = 0f;//distance of lunge
    public float lungeSpeed = 0f;//how fast lunge is 
    public bool isLunge = false;//determines if you are lun

    //Speed of charge up
    public float currentCharge = 0f;//starting charge
    public float chargeRate = 1f;//how fast it charges up
    public float maxCharge = 100f;//the maximum charge time
    public bool isCharging = false;//boolean for knowing if your charging
    public Slider chargeSlider;

    public Collider hitBox;//reference to hitbox collider

    //audio clips
    public AudioSource audioSource;
    public AudioClip mooSound;

    public CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();//controller for third person controller
        hitBox.enabled = false; 
    }

    void Update()
    {
        //updates charge meter and UI
        Charge();
        UpdateUI();
    }

    public void Charge()
    {
        //current charge starts at 0 but is charging is true
        if (Input.GetMouseButtonDown(0))
        {
            currentCharge = 0f;
            isCharging = true;
        }
        if (isCharging && Input.GetMouseButton(0))//if held down
        {
            currentCharge += chargeRate * Time.deltaTime;//smoothly charges up
            currentCharge = Mathf.Clamp(currentCharge, 0f, maxCharge);//will not exceed max charge

            UpdateUI();//update charge bar to show the slow charge up
        }
        if (Input.GetMouseButtonUp(0))//if let go at max charge
        {
            HitBoxDamage hitBoxDamage = GetComponent<HitBoxDamage>();

            if (currentCharge >= maxCharge)
            {
                StartCoroutine(PerformLunge());//lunge will happen is current = max
                //if ()
            }

            //current charge will start at 0 ischarging is false
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

    public IEnumerator PerformLunge()
    {
        isLunge = true;
        //float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + (transform.forward * lungeDistance);

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)//as long as distance between player and target position is greater than 0.1 loop will continue
        {
            controller.Move(transform.forward * lungeSpeed * Time.deltaTime);

            hitBox.enabled = true;//enable the hitbox when lunge is being performed

            yield return null;
        }

        hitBox.enabled = false;
        isLunge = false;
    }
}
