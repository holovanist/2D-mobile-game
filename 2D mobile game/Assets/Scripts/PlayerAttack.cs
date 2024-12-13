using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    RaycastHit2D[] hits;
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmount;
    [SerializeField] private float attackDelay = 0.15f;
    private float attacktimer;

    public bool DamageNow { get; private set; } = false;

    private List<IDamageable> iDamageables = new List<IDamageable>();

    private void Start()
    {
        attacktimer = attackDelay;
    }
    private void Update()
    {
        if (UserInput.instance.controls.Player.Melee.WasPressedThisFrame() && attacktimer >= attackDelay)
        {
            attacktimer = 0;
            Attack();
        }
        attacktimer = Time.deltaTime;
    }
    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);
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
    }

    public IEnumerator Damage2()
    {
        DamageNow = true;

        while (DamageNow)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);
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
