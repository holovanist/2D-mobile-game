using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    public float detectionRange = 5f;   // The range at which the enemy detects the player
    public float chaseSpeed = 3f;       // Speed at which the enemy chases the player

    private Transform player;           // Reference to the player's position
    private Rigidbody2D rb;             // Reference to the enemy's Rigidbody2D component
    private bool isChasing = false;     // Whether the enemy is currently chasing the player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        player = GameObject.FindWithTag("Player").transform; // Find the player by tag
    }

    void Update()
    {
        // Check if the player is within detection range using distance
        if (Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            isChasing = true;  // Start chasing if within range
        }
        else
        {
            isChasing = false; // Stop chasing if out of range
        }

        // If the enemy is chasing the player, call the ChasePlayer method
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            // No patrolling behavior, enemy just stays idle
            rb.linearVelocity = Vector2.zero; // Stop movement when not chasing
        }
    }

    void ChasePlayer()
    {
        // Get the direction to the player
        float direction = player.position.x > transform.position.x ? 1f : -1f;

        // Move towards the player on the x-axis
        rb.linearVelocity = new Vector2(direction * chaseSpeed, rb.linearVelocity.y);
    }
}
