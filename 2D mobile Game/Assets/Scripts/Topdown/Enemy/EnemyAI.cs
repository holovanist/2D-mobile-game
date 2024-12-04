using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = 5.0f;
    [SerializeField]
    float ChaseRange = 5.0f;
    [SerializeField]
    bool goHome = true;
    Vector3 homePosition;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        homePosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //the chase direction is destination - enemy starting position
        Vector3 playerPosition = player.transform.position;
        Vector3 ChaseDir = playerPosition - transform.position;
        Vector3 homeDir = homePosition - transform.position;
        if (ChaseDir.magnitude < ChaseRange)
        {
            //move towards the player
            ChaseDir.Normalize();
            rb.velocity = ChaseDir * chaseSpeed;
        }
        else if (goHome)
        {
            if (homeDir.magnitude < 0.1f)
            { 
                transform.position = homePosition;
                rb.velocity = Vector3.zero;
            }
            homeDir.Normalize();
            rb.velocity = homeDir * chaseSpeed;
        }
        else
        {

            rb.velocity = Vector3.zero;
        }
    }
}
