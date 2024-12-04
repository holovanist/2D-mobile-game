using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField]
    //string levelToLoad = "Lose";
    [SerializeField]
    float health = 10f;

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

    int counter;

    private UpgradeChecker UpgradeChecker;
    void Start()
    {
        UpgradeChecker = GetComponent<UpgradeChecker>();
        BaseMaxHealth = health;
        healthbar.fillAmount = health / BaseMaxHealth;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (health < 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            health = BaseMaxHealth;
        }
        if (UpgradeChecker.MaxHealthIncrease == true && counter < 1)
        {
            BaseMaxHealth *= 2;
            counter++;
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
        if (health <= BaseMaxHealth)
        {
            if (collision.gameObject.CompareTag("Heal"))
            {
                health += 1f;
                healthbar.fillAmount = health / BaseMaxHealth;
            }
        }
        if (collision.gameObject.CompareTag("Enemy Bullet") && timer >= iframes)
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