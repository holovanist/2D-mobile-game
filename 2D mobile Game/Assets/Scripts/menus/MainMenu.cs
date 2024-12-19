using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    string levelToLoad = "Level 1";
    public bool easy { get; set; }
    public bool medium { get; set; }
    public bool hard { get; set; }
    public bool pc { get; set; }
    public bool mobile { get; set; }
    public void Start()
    {
        easy = false;
        medium = false;
        hard = false;
        pc = false;
        mobile = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1.0f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Easy()
    {
        easy = true;
        SceneManager.LoadScene(levelToLoad);
    }
    public void Medium()
    {
        medium = true;
        SceneManager.LoadScene(levelToLoad);
    }
    public void Hard()
    {
        hard = true;
        SceneManager.LoadScene(levelToLoad);
    }
    public void PC()
    {
        pc = true;
        SceneManager.LoadScene(levelToLoad);
    }
    public void Mobile()
    {
        mobile = true;
        SceneManager.LoadScene(levelToLoad);
    }
}
