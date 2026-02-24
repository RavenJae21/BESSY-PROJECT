using UnityEngine;

public class HitBoxDamage : MonoBehaviour
{
    public int damageAmount;
    public bool hasHit = false; // Prevents multiple hits from a single attack swing

    public Player_Charge player_Charge;

    private void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other) // For 3D
    // private void OnTriggerEnter2D(Collider2D other) // For 2D
    {
        if (hasHit) return;
        if (!player_Charge.isLunge) return;
        // If it has a HealthManager, deal damage
        if (other.CompareTag("Breakable"))
        {
            Health health = other.GetComponent<Health>();

            health.TakeDamage(damageAmount);
            hasHit = true;
            // Optionally disable the hitbox or start a cooldown here
        }

        ResetHit();
    }
    
    // A function to reset 'hasHit' after the attack animation finishes
    public void ResetHit()
    {
        hasHit = false;
    }
}
