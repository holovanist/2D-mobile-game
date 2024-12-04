using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{
    GameObject boss;
    public string levelToLoad = "win";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boss = GameObject.FindWithTag("Boss");
        if (boss == null)
        { 
            SceneManager.LoadScene(levelToLoad); 
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        boss = GameObject.FindWithTag("Boss");
    }
}
