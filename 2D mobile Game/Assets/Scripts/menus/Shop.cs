using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Shop : MonoBehaviour
{
    GameObject shop3;
    GameObject shop4;
    GameObject shop5;



    public bool FireballUpgrade { get; set; }
    public bool MaxManaIncrease { get; set; }
    public bool MaxHealthIncrease { get; set; }

    private CoinCount CoinCount;

    public int Cost3;
    public int Cost4;
    public int Cost5;
    // Start is called before the first frame update
    void Start()
    {

        GameObject CoinCount1 = GameObject.FindWithTag("Player");
        if (CoinCount1 != null)
        {
            CoinCount = CoinCount1.GetComponent<CoinCount>();
        }
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GetComponent<Canvas>().enabled = true;
        }
        shop3 = GameObject.FindGameObjectWithTag("Shop 3");
        shop4 = GameObject.FindGameObjectWithTag("Shop 4");
        shop5 = GameObject.FindGameObjectWithTag("Shop 5");
    }

    public void Purchase3()
    {
        if (Cost3 <= CoinCount.MoneyAmount)
        {
            FireballUpgrade = true;
            shop3.SetActive(false);
            CoinCount.MoneyAmount -= Cost3;
        }
    }
    public void Purchase4()
    {
        if (Cost4 <= CoinCount.MoneyAmount)
        {
            MaxManaIncrease = true;
            shop4.SetActive(false);
            CoinCount.MoneyAmount -= Cost4;
        }
    }
    public void Purchase5()
    {
        if (Cost5 <= CoinCount.MoneyAmount)
        {
            MaxHealthIncrease = true;
            shop5.SetActive(false);
            CoinCount.MoneyAmount -= Cost5;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        GameObject CoinCount1 = GameObject.FindWithTag("Player");
        if (CoinCount1 != null)
        {
            CoinCount = CoinCount1.GetComponent<CoinCount>();
        }
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GetComponent<Canvas>().enabled = true;
        }
    }
}