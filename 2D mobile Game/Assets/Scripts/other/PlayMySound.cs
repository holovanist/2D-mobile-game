using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMySound : MonoBehaviour
{
    [SerializeField]
    AudioClip myClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(myClip);
        }
    }

}
