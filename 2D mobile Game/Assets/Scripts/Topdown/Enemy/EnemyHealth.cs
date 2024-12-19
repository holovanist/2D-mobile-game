using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    float health = 10f;
    [SerializeField]
    float BaseMaxHp = 10f;
    HUD HUD;
    int count;

    public void Start()
    {
        HUD = GetComponentInChildren<HUD>();
    }


    public void Damage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
