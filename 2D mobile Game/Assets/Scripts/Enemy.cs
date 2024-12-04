using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50; // Enemy health

    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add logic for the enemy's death (e.g., play death animation, destroy object, etc.)
        Destroy(gameObject); // For now, we just destroy the enemy
    }
}
