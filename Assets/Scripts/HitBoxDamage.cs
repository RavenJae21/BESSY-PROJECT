using UnityEditor;
using UnityEngine;

public class HitBoxDamage : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        Player_Charge charge = GetComponent<Player_Charge>();

        if(other.CompareTag("Obstacles"))
        {
            health.TakeDamage(charge.lungeDamage);
        }
    }
}
