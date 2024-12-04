using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject FireballLv1;
    [SerializeField]
    GameObject FireballLv2;
    [SerializeField]
    GameObject FireballLv1Y;
    [SerializeField]
    GameObject FireballLv2Y;
    [SerializeField]
    float BulletSpeed = 1.0f;
    [SerializeField]
    float BulletLifetime = 2.0f;
    float timer = 0;
    float timer2 = 0;
    [SerializeField]
    float ShootDelay = 0.5f;
    float xInput;
    float yInput;
    public int lastInput;
    public int lastInputY;
    int counter;


    public float Mana = 10;
    public float MaxMana { get; set; }
    [SerializeField]
    float RechargeAmount;
    [SerializeField]
    float ManaUsage;

    [SerializeField]
    Image Manabar;

    private UpgradeChecker UpgradeChecker;
    private void Start()
    {
        MaxMana = Mana;
        UpgradeChecker = GetComponent<UpgradeChecker>();
        Manabar.fillAmount = Mana / MaxMana;
        lastInput = -1;
    }
    // Update is called once per frame
    void Update()
    {
        timer2 += Time.deltaTime;
        if (Mana <= MaxMana && timer2 >= 2)
        {
            timer2 = 0;
            
            Mana += RechargeAmount;
            Manabar.fillAmount = Mana / MaxMana;
        }
        if (UpgradeChecker.MaxManaIncrease == true && counter <1)
        {
            MaxMana *= 2;
            counter++;
        }
        if (UpgradeChecker.FireballUpgrade == false)
        {
            ATK();
        } 
        else if (UpgradeChecker.FireballUpgrade == true)
        {   
            ATK2();
        }
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        if (xInput == 1)
        {
            lastInput = 1;
        }
        if (xInput == -1)
        {
            lastInput = -1;
        }
        if (yInput == 1)
        {
            lastInputY = 1;
        }
        if (yInput == -1)
        {
            lastInputY = -1;
        }

    }
    public void ATK()
    {
        
        if (Time.timeScale == 1)
        {
            timer += Time.deltaTime; 
            if (Input.GetButton("Fire1") && timer > ShootDelay && Mana >= 1)
            {
                timer = 0;
                Mana -= ManaUsage;
                Manabar.fillAmount = Mana / MaxMana;

                if (yInput != 0)
                {
                    GameObject ybullet = Instantiate(FireballLv1Y, transform.position, Quaternion.identity);
                    ybullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0 , yInput) * BulletSpeed;
                    Destroy(ybullet, BulletLifetime);
                    if (lastInputY < 0 || yInput < 0)
                    {
                        ybullet.GetComponent<SpriteRenderer>().flipY = true;
                    }
                }

                else if (xInput != 0)
                {
                    GameObject xbullet = Instantiate(FireballLv1, transform.position, Quaternion.identity);
                    xbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(xInput, 0) * BulletSpeed;
                    if (lastInput < 0 || xInput < 0)
                    {
                       xbullet.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    Destroy(xbullet, BulletLifetime);
                }
                else if (xInput == 0)
                {
                    GameObject xbullet = Instantiate(FireballLv1, transform.position, Quaternion.identity);
                    xbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(lastInput, 0) * BulletSpeed;
                    if (lastInput < 0 || xInput < 0)
                    {
                        xbullet.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    Destroy(xbullet, BulletLifetime);
                }
            }
        }
    }
    public void ATK2()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");
        if (Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            if (Input.GetButton("Fire1") && timer > ShootDelay)
            {
                timer = 0;
                Mana -= ManaUsage;
                Manabar.fillAmount = Mana / MaxMana;

                if (yInput != 0)
                {
                    GameObject ybullet = Instantiate(FireballLv2Y, transform.position, Quaternion.identity);
                    ybullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, yInput) * BulletSpeed;
                    Destroy(ybullet, BulletLifetime);
                    if (lastInputY < 0 || yInput < 0)
                    {
                        ybullet.GetComponent<SpriteRenderer>().flipY = true;
                    }
                }
                else if (xInput != 0)
                {
                    GameObject xbullet = Instantiate(FireballLv2, transform.position, Quaternion.identity);
                    xbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(xInput, 0) * BulletSpeed;
                    if (lastInput < 0 || xInput < 0)
                    {
                        xbullet.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    Destroy(xbullet, BulletLifetime);
                }
                else if (xInput == 0)
                {
                    GameObject xbullet = Instantiate(FireballLv2, transform.position, Quaternion.identity);
                    xbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(lastInput, 0) * BulletSpeed;
                    if (lastInput < 0 || xInput < 0)
                    {
                        xbullet.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    Destroy(xbullet, BulletLifetime);
                }
            }
        }
    }
}
