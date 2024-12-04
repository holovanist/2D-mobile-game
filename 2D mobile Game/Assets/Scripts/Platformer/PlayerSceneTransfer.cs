using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerSceneTransfer : MonoBehaviour
{
    GameObject SpawnPos;
    GameObject menu;
    GameObject player;

    public string levelToLoad = "Logan 2";
    public bool OriginalPlayer = false;

    // Start is called before the first frame update
    void Start()
    {

        menu = GameObject.FindGameObjectWithTag("menu");
        player = GameObject.FindGameObjectWithTag("Player");
        SpawnPos = GameObject.FindGameObjectWithTag("Scene Start Point 1");
        if (player != null)
        {
            OriginalPlayer = true;
        }
        menu = GameObject.FindGameObjectWithTag("menu");
        if (menu != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }
        if (menu == null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
        }
    }

    void Awake()
    {
            if (CompareTag("Player"))
            {
                DontDestroyOnLoad(this.gameObject);
            }
        SpawnPos = GameObject.FindGameObjectWithTag("Scene Start Point 1");
        gameObject.transform.position = SpawnPos.transform.position;
    }
    private void OnLevelWasLoaded(int level)
    {
        
        menu = GameObject.FindGameObjectWithTag("menu");
        if (menu != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }
        if (menu == null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
        }
        if (OriginalPlayer == false)
        {
            Destroy(gameObject);
        }
        SpawnPos = GameObject.FindGameObjectWithTag("Scene Start Point 1");
        gameObject.transform.position = SpawnPos.transform.position;
        menu = GameObject.FindGameObjectWithTag("menu");
    }
}
