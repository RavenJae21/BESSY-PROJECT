using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth = 100f;//the amount of health starting

    public void TakeDamage(float lungeDamage)
    {
        currentHealth -= lungeDamage;//dmg will subtract hp

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
