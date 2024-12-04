using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float JumpForce;
    private float moveInput;

    private bool isgrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private float JumptimeCounter;
    public float JumpTime;
    private bool IsJumping;
    Animator anim;
    UpgradeChecker UpgradeChecker;
    [SerializeField]
    float timer;
    void Start()
    {
        UpgradeChecker = GetComponent<UpgradeChecker>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
    }
    private void Update()
    {
        
        if (Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            if (Input.GetButton("Fire1") && timer >= .5)
            {
                timer = 0;
                anim.SetTrigger("click");
            }
        }
        isgrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);
        if (isgrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            JumptimeCounter = JumpTime;
            rb.velocity = Vector2.up * JumpForce;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (JumptimeCounter > 0 && IsJumping == true)
            {
                rb.velocity = Vector2.up * JumpForce;
                JumptimeCounter -= Time.deltaTime;
            }
            else
            {
                IsJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }
        anim.SetBool("Grounded", isgrounded);
        int x = (int)Input.GetAxisRaw("Horizontal");
        anim.SetInteger("x", x);
        if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        anim.SetBool("upgrade", UpgradeChecker.FireballUpgrade);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isgrounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isgrounded = true;
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }*/
}
