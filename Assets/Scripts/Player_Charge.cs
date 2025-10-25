using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player_Charge : MonoBehaviour
{
    //lunge dmg, dist, spd
    public float lungeDamage = 5f;//variable for how much charge damage
    public float lungeDistance = 0f;//distance of lunge
    public float lungeSpeed = 0f;//how fast lunge is 
    public bool isLunge = false;//determines if you are lun

    //Speed of charge up
    public float currentCharge = 0f;//starting charge
    public float chargeRate = 1f;//how fast it charges up
    public float maxCharge = 100f;//the maximum charge time
    public bool isCharging = false;//boolean for knowing if your charging
    public Slider chargeSlider;

    //audio clips
    public AudioSource audioSource;
    public AudioClip mooSound;

    public CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        //updates charge meter
        Charge();
        UpdateUI();
    }

    public void OnTriggerEnter(Collider other)
    {
        Health healthScript = other.GetComponent<Health>();

        if (healthScript != null)
        {
            healthScript.TakeDamage(lungeDamage);
        }
    }

    public void Charge()
    {
        if (Input.GetMouseButtonDown(0))//if press left click
        {
            currentCharge = 0f;
            isCharging = true;
        }
        if (isCharging && Input.GetMouseButton(0))//if let go
        {
            currentCharge += chargeRate * Time.deltaTime;//smoothly charges up
            currentCharge = Mathf.Clamp(currentCharge, 0f, maxCharge);//will not exceed max charge

            UpdateUI();
        }
        if (Input.GetMouseButtonUp(0))//if let go at max charge
        {
            if(currentCharge >= maxCharge)
            {
                StartCoroutine(PerformLunge());
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

    public IEnumerator PerformLunge()
    {
        isLunge = true;
        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + (transform.forward * lungeDistance);

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)//as long as distance between player and target position is greater than 0.1 loop will continue
        {
            controller.Move(transform.forward * lungeSpeed * Time.deltaTime);

            yield return null;
        }

        isLunge = false;
    }
}
