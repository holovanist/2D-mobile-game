using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDisapear : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("gem"))
        {
            collison.gameObject.SetActive(false);
        }
    }
}