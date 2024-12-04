using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        string name = "James";
        Debug.Log(name);
        int health = 10;
        //float critChance = 0.2f;
        //bool key = true;
        Debug.Log("health = " + health);
        //all below subtract 1 from the value of health
        //health = health - 1;
        health -= 1;
        health--;
        Debug.Log("health = " + health);
        //all below add 1 from the value of health
        //health = health + 1;
        health += 1;
        health++;
        Debug.Log("health = " + health);
    }

}
