using UnityEditor;
using UnityEngine;

public class HitBoxDamage : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();//call the health script
        Player_Charge charge = GetComponent<Player_Charge>();//call the player charge script

        if(other.CompareTag("Obstacles"))//look for obstacles tag
        {
            health.TakeDamage(charge.lungeDamage);//call both health and charge script and take x dmg
        }
    }
}
