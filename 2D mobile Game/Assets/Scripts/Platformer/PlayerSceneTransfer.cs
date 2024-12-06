using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerSceneTransfer : MonoBehaviour
{
    GameObject SpawnPos;
    GameObject SpawnPosUp;
    GameObject SpawnPosDown;
    GameObject SpawnPosLeft;
    GameObject SpawnPosRight;
    GameObject menu;
    GameObject player;
    int up;
    int down;
    int left;
    int right;

    public string levelToLoad = "Logan 2";
    public bool OriginalPlayer = false;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        SpawnPosUp = GameObject.FindGameObjectWithTag("Start Up");
        if (SpawnPosUp == null) { }
        SpawnPosDown = GameObject.FindGameObjectWithTag("Start Down");
        if (SpawnPosDown == null) { }
        SpawnPosLeft = GameObject.FindGameObjectWithTag("Start Left");
        if (SpawnPosLeft == null) { }
        SpawnPosRight = GameObject.FindGameObjectWithTag("Start Right");
        if (SpawnPosRight == null) { }
        SpawnPos = GameObject.FindGameObjectWithTag("Start");
        if (SpawnPos == null) { }
        if (player != null)
        {
            OriginalPlayer = true;
        }
        menu = GameObject.FindGameObjectWithTag("Menu");
        if (menu != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }
        if (menu == null)
        {
            //GetComponent<SpriteRenderer>().enabled = true;
            //GetComponentInChildren<Canvas>().enabled = true;
        }
    }

    void Awake()
    {
            if (CompareTag("Player"))
            {
                DontDestroyOnLoad(this.gameObject);
            }
        SpawnPos = GameObject.FindGameObjectWithTag("Start");
        if (SpawnPos == null) { }
        else { gameObject.transform.position = SpawnPos.transform.position; }
    }
    private void OnLevelWasLoaded(int level)
    {
       up = 0; down = 0; left = 0; right = 0;
        
        menu = GameObject.FindGameObjectWithTag("Menu");
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
        SpawnPosUp = GameObject.FindGameObjectWithTag("Start Up");
        if (SpawnPosUp == null) { }
        SpawnPosDown = GameObject.FindGameObjectWithTag("Start Down");
        if (SpawnPosDown == null) { }
        SpawnPosLeft = GameObject.FindGameObjectWithTag("Start Left");
        if (SpawnPosLeft == null) { }
        SpawnPosRight = GameObject.FindGameObjectWithTag("Start Right");
        if (SpawnPosRight == null) { }
        SpawnPos = GameObject.FindGameObjectWithTag("Start");
        if (SpawnPos == null) { }
        menu = GameObject.FindGameObjectWithTag("Menu");
            if (menu == null) { }
        if(up == 1)
        { gameObject.transform.position = SpawnPosUp.transform.position; }
        if (down == 1)
        { gameObject.transform.position = SpawnPosDown.transform.position; }
        if(left == 1)
        { gameObject.transform.position = SpawnPosLeft.transform.position; }
        if(right == 1)
        { gameObject.transform.position = SpawnPosRight.transform.position; }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Up"))
            {up = 1; down = 0; left = 0; right = 0;} else { }
        if(coll.CompareTag("Down"))
            {down = 1; up = 0; left = 0; right = 0;} else { }
        if(coll.CompareTag("Left"))
            {left = 1; up = 0; down = 0; right = 0;} else { }
        if (coll.CompareTag("Right"))
            {right = 1; up = 0; left = 0; down = 0;} else { }
    }
}
