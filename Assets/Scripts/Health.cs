using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;//the amount of health starting

    public void TakeDamage(float lungeDamage)
    {
        currentHealth -= lungeDamage;//dmg will subtract from current hp

        if (currentHealth <= 0)
        {
            Die();//call when thing is at 0
        }
    }

    public void Die()
    {
        Destroy(gameObject);

    }
}
