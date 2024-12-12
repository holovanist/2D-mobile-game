using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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
    int xInput;
    int yInput;
    public int lastInput;
    public int lastInputY;


    public float Mana = 10;
    public float MaxMana { get; set; }
    [SerializeField]
    float RechargeAmount;
    [SerializeField]
    float ManaUsage;
    [SerializeField]
    Image Manabar;

    public float HealAmount;

    PlayerHealth PlayerHealth;

    private @InputSystem_Actions playerInputActions;
    private InputAction Attack;
    private InputAction moveAction;
    public float HealTime;

    private void Start()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        MaxMana = Mana;
        Manabar.fillAmount = Mana / MaxMana;    
        lastInput = -1;
        playerInputActions = new @InputSystem_Actions();
        Attack = playerInputActions.Player.Attack;
        moveAction = playerInputActions.Player.Move;

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
            ATK(); 
        Vector2 moveInputVector = moveAction.ReadValue<Vector2>();
        xInput = (int)moveInputVector.x;
        yInput = (int)moveInputVector.y;
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
            if (Attack.triggered && timer > ShootDelay && Mana >= 1)
            {
                timer = 0;
                Mana -= ManaUsage;
                Manabar.fillAmount = Mana / MaxMana;

                if (yInput != 0)
                {
                    GameObject ybullet = Instantiate(FireballLv1Y, transform.position, Quaternion.identity);
                    ybullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0 , yInput) * BulletSpeed;
                    Destroy(ybullet, BulletLifetime);
                    if (lastInputY < 0 || yInput < 0)
                    {
                        ybullet.GetComponent<SpriteRenderer>().flipY = true;
                    }
                }

                else if (xInput != 0)
                {
                    GameObject xbullet = Instantiate(FireballLv1, transform.position, Quaternion.identity);
                    xbullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(xInput, 0) * BulletSpeed;
                    if (lastInput < 0 || xInput < 0)
                    {
                       xbullet.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    Destroy(xbullet, BulletLifetime);
                }
            }
        }
    }
    public void Heal()
    {
        if (Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            if (Attack.IsPressed())
            {
                HealTime = Time.deltaTime;
                if (yInput == 0 && xInput == 0 && HealTime >= .25)
                {
                    PlayerHealth.health += 2;
                    HealTime = 0;
                }
            }
        }
    }
}
