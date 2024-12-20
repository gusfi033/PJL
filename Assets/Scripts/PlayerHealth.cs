using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;  // Player's health
    public bool isDead = false;  // Flag to track if the player is dead

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        // Handle death logic here, like playing death animation, stopping movement, etc.
        Debug.Log("Player has died!");

        // Optionally, you could disable the player's movement or show a game over screen here
        // For example, you can disable the player's movement component
        GetComponent<PlayerMovement>().enabled = false;

        // Trigger death animation or effect
        // Example: Animator.SetTrigger("Die");
    }
}
