using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float BulletSpeed = 10.0f;
    [SerializeField]
    float BulletLifetime = 2.0f;
    float timer = 0;
    [SerializeField]
    float ShootDelay = 0.5f;
    GameObject Player;
    [SerializeField]
    float shootDistance = 5f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if player gets within a certin distance
        Vector3 shootDir = Player.transform.position - transform.position;
        if (shootDir.magnitude < shootDistance && timer > ShootDelay)
        {
        
            //delay the next bullet
            //spawn the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //push the bullet towards the player
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * BulletSpeed;
            //shoot towards the player
            timer = 0;
            Destroy(bullet, BulletLifetime);
            anim.SetBool("shoot", true);
        } else
        {
            anim.SetBool("shoot", false);
        }
        
    }
    private void OnLevelWasLoaded(int level)
    {
        anim = GetComponent<Animator>();
    }
}
