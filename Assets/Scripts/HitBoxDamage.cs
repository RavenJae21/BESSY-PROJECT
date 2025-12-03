using UnityEditor;
using UnityEngine;

public class HitBoxDamage : MonoBehaviour
{
    public int damageAmount;
    private bool hasHit = false; // Prevents multiple hits from a single attack swing


    private void Start()
    {
        hasHit = false; 
    }
    public void OnTriggerEnter(Collider other) // For 3D
    // private void OnTriggerEnter2D(Collider2D other) // For 2D
    {
        // Try to get the HealthManager component from the object we hit
        Health health = other.GetComponent<Health>();

        // If it has a HealthManager, deal damage
        if (health != null && !hasHit)
        {
            health.TakeDamage(damageAmount);
            hasHit = true;
            // Optionally disable the hitbox or start a cooldown here
        }
    }
    
    // A function to reset 'hasHit' after the attack animation finishes
    public void ResetHit()
    {
        hasHit = false;
    }
}
