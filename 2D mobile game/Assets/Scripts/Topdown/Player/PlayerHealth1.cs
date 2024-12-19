using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField]
    //string levelToLoad = "Lose";

    public float health = 10f;

    public float BaseMaxHealth { get; set; }
    [SerializeField]
    float BossDamage = 2f;
    [SerializeField]
    float EnemyDamage = 1f;
    [SerializeField]
    Image healthbar;
    [SerializeField]
    float iframes;
    float timer;
    int count;
    HUD HUD;

    void Start()
    {
        HUD = GetComponentInChildren<HUD>();
        BaseMaxHealth = health;
        healthbar.fillAmount = health / BaseMaxHealth;
    }
    private void Update()
    {
        if (count == 0)
        {
            if(HUD.easy == true)
            {
                BossDamage *= .05f;
                EnemyDamage *= .05f;
                count = 1;
            }
            if (HUD.medium == true)
            {
                BossDamage *= 1;
                EnemyDamage *= 1;
                count = 1;
            }
            if (HUD.hard == true)
            {
                count = 1;
                BossDamage *= 2;
                EnemyDamage *= 2;
            }
        }
        timer += Time.deltaTime;
        if (health < 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            health = BaseMaxHealth;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && timer >= iframes)
        {
            EnemyHit();
        }
        if (collision.gameObject.CompareTag("Boss") && timer >= iframes)
        {
            BossHit();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && timer >= iframes)
        {
            EnemyHit();
        }
        if (collision.gameObject.CompareTag("Boss") && timer >= iframes)
        {
            BossHit();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && timer >= iframes)
        {
            EnemyHit();
        }
        if (collision.gameObject.CompareTag("Boss") && timer >= iframes)
        {
            BossHit();
        }
        if (collision.gameObject.CompareTag("EBullet") && timer >= iframes)
        {
            BossHit();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && timer >= iframes)
        {
            EnemyHit();
        }
        if (collision.gameObject.CompareTag("Boss") && timer >= iframes)
        {
            BossHit();
        }
    }
    public void EnemyHit()
    {
        health -= EnemyDamage;
        timer = 0;
        healthbar.fillAmount = health / BaseMaxHealth;
    }
    public void BossHit()
    {
        health -= BossDamage;
        timer = 0;
        healthbar.fillAmount = health / BaseMaxHealth;
    }
    private void OnLevelWasLoaded(int level)
    {
        health = BaseMaxHealth;
        healthbar.fillAmount = health / BaseMaxHealth;
    }
}