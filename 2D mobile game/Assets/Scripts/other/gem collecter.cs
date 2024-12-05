using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gemcollecter : MonoBehaviour
{
    GameObject gem;
    public string levelToLoad = "Level 4 beta";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gem = GameObject.FindWithTag("gem");
        if (gem == null)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
