using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPlatformer : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = 5.0f;
    [SerializeField]
    float ChaseRange = 5.0f;
    [SerializeField]
    bool goHome = true;
    Vector3 homePosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        homePosition = transform.position;
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
            GetComponent<Rigidbody2D>().velocity = ChaseDir * chaseSpeed;
        }
        else if (goHome)
        {
            if (homeDir.magnitude < 0.1f)
            { 
                transform.position = homePosition;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
            homeDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = homeDir * chaseSpeed;
        }
        else
        {

            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
