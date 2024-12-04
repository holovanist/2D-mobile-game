using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            if (timer < 20)
            {
                GameObject Enemy = Instantiate(prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
