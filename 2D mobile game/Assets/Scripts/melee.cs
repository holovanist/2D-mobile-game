using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack1 : MonoBehaviour
{
    RaycastHit2D[] hits;
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmount;
    [SerializeField] private float attackDelay = 0.15f;
    private float attacktimer;

    private Animator anim;

    // Directional movement distances for the attack
    [SerializeField] private float attackMoveDistance = 0.5f;  // Distance the attack moves when held
    private Vector2 attackDirection;

    public bool DamageNow { get; private set; } = false;

    private List<IDamageable> iDamageables = new List<IDamageable>();

    private void Start()
    {
        attacktimer = attackDelay;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Get the input direction (could be changed based on your input system)
        Vector2 moveInput = UserInput.instance.controls.Player.Move.ReadValue<Vector2>();

        // Determine the attack direction based on input
        if (moveInput.x > 0) attackDirection = Vector2.right; // Right
        else if (moveInput.x < 0) attackDirection = Vector2.left; // Left
        else if (moveInput.y > 0) attackDirection = Vector2.up; // Up
        else if (moveInput.y < 0) attackDirection = Vector2.down; // Down
        else attackDirection = Vector2.right; // Default to right if no input

        // Check for attack input
        if (UserInput.instance.controls.Player.Melee.WasPressedThisFrame() && attacktimer >= attackDelay)
        {
            attacktimer = 0;
            StartCoroutine(Attack());
            anim.SetTrigger("atk");
        }

        attacktimer += Time.deltaTime;
    }

    private IEnumerator Attack()
    {
        // Store the original position of the attack transform
        Vector3 originalPosition = attackTransform.position;

        // Move the attack position in the direction of the attack
        attackTransform.position += (Vector3)(attackDirection * attackMoveDistance);

        // Perform the attack (raycast or circle cast) at the new position
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, Vector2.zero, 0f, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            EnemyHealth enemyhealth = hits[i].collider.GetComponent<EnemyHealth>();

            if (enemyhealth != null)
            {
                IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                if (iDamageable != null && !iDamageables.Contains(iDamageable))
                {
                    iDamageable.Damage(damageAmount);
                    iDamageables.Add(iDamageable);
                }
            }
        }

        // Return the attack transform back to its original position after the attack
        float timeElapsed = 0f;
        float returnDuration = 0.1f; // The duration of the return

        while (timeElapsed < returnDuration)
        {
            attackTransform.position = Vector3.Lerp(attackTransform.position, originalPosition, timeElapsed / returnDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the attack transform is exactly at its original position
        attackTransform.position = originalPosition;
    }

    public IEnumerator Damage2()
    {
        DamageNow = true;

        while (DamageNow)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, Vector2.zero, 0f, attackableLayer);
            for (int i = 0; i < hits.Length; i++)
            {
                EnemyHealth enemyhealth = hits[i].collider.GetComponent<EnemyHealth>();

                if (enemyhealth != null)
                {
                    IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                    if (iDamageable != null && !iDamageables.Contains(iDamageable))
                    {
                        iDamageable.Damage(damageAmount);
                        iDamageables.Add(iDamageable);
                    }
                }
            }
            yield return null;
        }

        ReturnAttackableToDamagable();
    }

    private void ReturnAttackableToDamagable()
    {
        iDamageables.Clear();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

    #region Animation Triggers
    public void DamageNowToTrue()
    {
        DamageNow = true;
    }

    public void DamageNowToFalse()
    {
        DamageNow = false;
    }
    #endregion
}
