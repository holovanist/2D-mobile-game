using UnityEngine;

public class HUD : MonoBehaviour
{
    MainMenu menu;
    GameObject GameObject;
    GameObject hud;
    public bool easy {  get; set; }
    public bool medium {  get; set; }
    public bool hard {  get; set; }
    int count;
    public void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>();
        hud = GameObject.FindGameObjectWithTag("Mobile");
        count = 1;
        if (menu.pc == true)
        {
            hud.SetActive(false);
        }

    }

    public void Update()
    {
        if (!menu.easy && !menu.medium)
        {
            if (!hard)
            {
                menu.hard = hard;
            }
        }
        if (!menu.easy && !menu.hard)
        {
            if (!medium)
            {
                menu.medium = medium;
            }
        }
        if (!menu.hard && !menu.medium)
        {
            if (!easy)
            {
                menu.easy = easy;
            }
        }
    }
    public void OnLevelWasLoaded(int level)
    {
        if (count == 1)
        {
            GameObject = GameObject.FindGameObjectWithTag("Menu");
            if (GameObject != null)
            {
                menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>();
            }
        }
    }
}
