using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float attackRange = 2f; // Range of the melee attack
    public int attackDamage = 10;  // Damage dealt to enemies
    public float attackCooldown = 0.5f; // Time between attacks to avoid spam

    private float lastAttackTime = 0f; // Track time of last attack
    private Animator animator; // Reference to player's animator

    // References for player attack hitbox
    public Transform attackPoint;  // Position where the attack will happen
    public LayerMask enemyLayer;   // Layer that represents enemies

    void Start()
    {
        // Get the Animator component if needed (for animations)
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Listen for the attack input (e.g., pressing "Space" to attack)
        if (Time.time >= lastAttackTime + attackCooldown && Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Play attack animation if one exists (optional)
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Update last attack time
        lastAttackTime = Time.time;

        // Check for enemies within attack range (using a CircleCast for simplicity)
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Deal damage to the enemy (you need to have an Enemy script with a TakeDamage function)
            enemy.GetComponent<Enemy>()?.TakeDamage(attackDamage);
        }
    }

    // Debugging the attack range in the scene view (only in editor)
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
