using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

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
    //Animator anim;
    [SerializeField]
    InputActionReference moveActionReference;
    [SerializeField]
    InputActionReference jump;
    float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
    private void Update()
    {
        if(JumptimeCounter > 0 && IsJumping == true)
        {
            JumptimeCounter -= Time.deltaTime;
        }
        /*if (Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            if (Input.GetButton("Fire1") && timer >= .5)
            {
                timer = 0;
                anim.SetTrigger("click");
            }
        }*/
        isgrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);
        if (isgrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            JumptimeCounter = JumpTime;
            rb.linearVelocity = Vector2.up * JumpForce;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (JumptimeCounter > 0 && IsJumping == true)
            {
                rb.linearVelocity = Vector2.up * JumpForce;
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
        /*anim.SetBool("Grounded", isgrounded);
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
    */
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isgrounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isgrounded = true;
        }
    }
    public void Jump()
    {
        if (isgrounded == true && jump || isgrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            JumptimeCounter = JumpTime;
            rb.linearVelocity = Vector2.up * JumpForce;
        }
        if (jump || Input.GetKeyDown(KeyCode.Space))
        {
            if (JumptimeCounter > 0 && IsJumping == true)
            {
                rb.linearVelocity = Vector2.up * JumpForce;
                JumptimeCounter -= Time.deltaTime;
            }
            else
            {
                IsJumping = false;
            }
        }
        if (jump)
        {
            IsJumping = false;
        }
    }
    public void Timer()
    {
        JumptimeCounter = Time.deltaTime;
    }
}
