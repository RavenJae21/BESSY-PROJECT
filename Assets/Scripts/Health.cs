using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;//the amount of health starting
    public float maxHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;//dmg will subtract hp

        if (currentHealth <= 0)
        {
            Die();//call when health is at 0
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
