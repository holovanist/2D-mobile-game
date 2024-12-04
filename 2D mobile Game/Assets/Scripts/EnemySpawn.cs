using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
   
    int NumberOfEnemiesSpawned;
    [SerializeField]
    int NumberOfEnemiesSpawnable = 5;
    float timer;
    float timer2;
    private void Start()
    {
        NumberOfEnemiesSpawned = 0;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (GameObject.FindWithTag("Enemy") == true && NumberOfEnemiesSpawned < NumberOfEnemiesSpawnable)
        {
            GameObject _ = Instantiate(prefab, transform.position, Quaternion.identity);
            NumberOfEnemiesSpawned++;
        }
        else if (GameObject.FindWithTag("Enemy") == null && NumberOfEnemiesSpawned < NumberOfEnemiesSpawnable)
        {
            _ = Instantiate(prefab, transform.position, Quaternion.identity);
            NumberOfEnemiesSpawned++;
        }
        else if (GameObject.FindWithTag("Enemy") == null && NumberOfEnemiesSpawned == NumberOfEnemiesSpawnable && timer > 5f)
        {
            timer = 0;
            timer2 = 0;
            //NumberOfEnemiesSpawned = 0;
        }
            if (GameObject.FindWithTag("Enemy") == null && NumberOfEnemiesSpawned == NumberOfEnemiesSpawnable && timer2 > 5f)
        {
            //timer = 0;
            NumberOfEnemiesSpawned = 0;
        }
        Debug.Log(NumberOfEnemiesSpawned);
    }
}
