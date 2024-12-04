using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public int CoinAmount;
    public TextMeshProUGUI MyText;
    public int MoneyAmount { get; set; }

    // Use this for initialization
    void Start()
    {
        MyText.text = "";
    }


    // Update is called once per frame
    void Update()
    {

        MyText.text = "money " + MoneyAmount;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("Coin"))
        {
            MoneyAmount += CoinAmount;
        }

        if (coll.CompareTag("Coin"))
        {
            coll.gameObject.SetActive(false);
        }

    }
}
