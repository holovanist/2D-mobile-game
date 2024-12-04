using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth1 : MonoBehaviour
{
    [SerializeField]
    //string levelToLoad = "Lose";
    //[SerializeField]
    float health = 50f;
    [SerializeField]
    float baseMaxHealth = 100f;
    [SerializeField]
    float DamagePerFrame = 0.05f;
    [SerializeField]
    float DamageOnContact = 1f;
    [SerializeField]
    Image healthbar;
    void Start()
    {
        //baseMaxHealth = health;
        healthbar.fillAmount = health / baseMaxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        //IF we it an enemy, reduce player hp
        if(collision.gameObject.tag == "Enemy")
        {
            health -= DamageOnContact;
            healthbar.fillAmount = health / baseMaxHealth;
            //add consequences
            //IF health gets too low, reload the current level
            if (health < 1f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {   
            health -= DamagePerFrame;
            healthbar.fillAmount = health / baseMaxHealth;
            if (health < 1f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= DamagePerFrame;
            healthbar.fillAmount = health / baseMaxHealth;
            if (health < 1f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
        if (health <= baseMaxHealth)
        {
            if (collision.gameObject.tag == "Healing pool")
            {
                health += 1f;
                healthbar.fillAmount = health / baseMaxHealth;
            }
        }
        if (collision.gameObject.tag == "Enemy Bullet")
        {
            health -= DamageOnContact;
            healthbar.fillAmount = health / baseMaxHealth;
            if (health < 1f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= DamagePerFrame;
            healthbar.fillAmount = health / baseMaxHealth;
            if (health < 1f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
        if (health <= baseMaxHealth)    
        {
           if (collision.gameObject.tag == "Healing pool")
           {
                health += .05f;
                healthbar.fillAmount = health / baseMaxHealth;
            }
        }
    }
}