using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UpgradeChecker : MonoBehaviour
{

    public bool LightningSpells { get; set; }
    public bool LightningSpellsUpgrade { get; set; }
    public bool FireballUpgrade { get; set; }
    public bool MaxManaIncrease { get;  set; }
    public bool MaxHealthIncrease { get;  set; }

    ShopManager ShopManager;

    // Update is called once per frame
    private void Start()
    {

        GameObject shop1 = GameObject.FindWithTag("Store");
        //Store = GameObject.FindGameObjectWithTag("Store");
        //GetComponent<Shop>();
        if (shop1 != null)
        {
            ShopManager = shop1.GetComponent<ShopManager>();
        }
    }
    void Update()
    {
       
        if (ShopManager.item2Purchased == true)
        {
            FireballUpgrade = true;
        }
        else
        {

        }
        if(ShopManager.item3Purchased == true) 
        {
            MaxManaIncrease = true;
        }
        else
        {

        }
        if(ShopManager.item1Purchased == true)
        {
            MaxHealthIncrease = true;
        }
        else if (ShopManager.item1Purchased == false) 
        {

        }
    }
}
