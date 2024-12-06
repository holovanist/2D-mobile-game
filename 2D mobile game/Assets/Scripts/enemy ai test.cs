using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyPaceTest : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = 5.0f;
    [SerializeField]
    float ChaseRange = 5.0f;
    float paceDir = -1;
    public float paceSpeed = 4;
    Rigidbody2D rb;
    float timer;
    public float StopChaseTime = 2;
    //Animator anim;
    bool isChasing = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 ChaseDir = playerPosition - transform.position;

        if (ChaseDir.magnitude < ChaseRange)
        {
            isChasing = true;
        }
        timer += Time.deltaTime;

        if (isChasing & timer >= StopChaseTime)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 ChaseDir = playerPosition - transform.position;

        if (ChaseDir.magnitude < ChaseRange)
        {
            // Move towards the player
            ChaseDir.Normalize();
            rb.linearVelocity = new Vector2(ChaseDir.x * chaseSpeed, rb.linearVelocity.y);
            //anim.SetInteger("move", ChaseDir.x > 0 ? 1 : -1);
        }
        else
        {
            // Stop chasing when the player is out of range
            isChasing = false;
        }
    }

   
    void Patrol()
    {
        Vector3 vel = rb.linearVelocity;
        vel.x = paceDir * paceSpeed;
        rb.linearVelocity = vel;
        //anim.SetInteger("move", paceDir > 0 ? 1 : -1);
    }

    //anim.SetInteger("move", paceDir > 0 ? 1 : -1); // Return to the current patrol direction
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isChasing = false;
            paceDir *= -1;
            timer = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") & timer >= 2)
        {
            timer = 0;
            paceDir *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //anim.SetFloat("atk", 2);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //anim.SetFloat("atk", 0);
        }
    }
}
