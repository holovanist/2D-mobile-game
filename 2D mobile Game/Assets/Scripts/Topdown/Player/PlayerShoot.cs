using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot1 : MonoBehaviour
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
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale ==1)
        {
            timer += Time.deltaTime; //0.016667 = 60fps
                                 //if you click
            if (Input.GetButton("Fire1") && timer > ShootDelay)
            {
                timer = 0;
                //shoot towards the mouse cursor
                Vector3 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                mousePos.z = 0;
                Vector3 mouseDir = mousePos - transform.position;
                //normalize the vector so we dont have wonky speeds
                mouseDir.Normalize();
                //spawn in the bullet
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                //Push the bullet towards the mouse
                bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * BulletSpeed;
                Destroy(bullet, BulletLifetime);
            }
        }
    }
}
