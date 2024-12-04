using UnityEngine;
using UnityEngine.UI;  // Importing UI namespace

public class ShopManager : MonoBehaviour
{
    // Boolean flags for each purchasable item
    public bool item1Purchased = false;
    public bool item2Purchased = false;
    public bool item3Purchased = false;

    // UI Buttons for purchasing items
    public Button item1Button;
    public Button item2Button;
    public Button item3Button;

    // Text to display status (optional)
    public Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        // Assign button click listeners to handle purchases
        item1Button.onClick.AddListener(PurchaseItem1);
        item2Button.onClick.AddListener(PurchaseItem2);
        item3Button.onClick.AddListener(PurchaseItem3);

        // Update the UI to show the current purchase status
        UpdateUI();
    }

    // Method to handle purchasing Item 1
    void PurchaseItem1()
    {
        if (!item1Purchased)
        {
            item1Purchased = true;
            UpdateUI();
            Debug.Log("Item 1 Purchased!");
        }
        else
        {
            Debug.Log("Item 1 already purchased!");
        }
    }

    // Method to handle purchasing Item 2
    void PurchaseItem2()
    {
        if (!item2Purchased)
        {
            item2Purchased = true;
            UpdateUI();
            Debug.Log("Item 2 Purchased!");
        }
        else
        {
            Debug.Log("Item 2 already purchased!");
        }
    }

    // Method to handle purchasing Item 3
    void PurchaseItem3()
    {
        if (!item3Purchased)
        {
            item3Purchased = true;
            UpdateUI();
            Debug.Log("Item 3 Purchased!");
        }
        else
        {
            Debug.Log("Item 3 already purchased!");
        }
    }

    // Method to update the UI based on purchase status
    void UpdateUI()
    {
        // Optionally, display the status of items in a Text UI
        if (statusText != null)
        {
            statusText.text = $"Item 1: {(item1Purchased ? "Purchased" : "Available")}\n" +
                              $"Item 2: {(item2Purchased ? "Purchased" : "Available")}\n" +
                              $"Item 3: {(item3Purchased ? "Purchased" : "Available")}";
        }

        // Disable buttons for already purchased items (optional)
        item1Button.interactable = !item1Purchased;
        item2Button.interactable = !item2Purchased;
        item3Button.interactable = !item3Purchased;

    }
    private void OnLevelWasLoaded(int level)
    {
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
