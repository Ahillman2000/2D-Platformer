using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadPlayMenu()
    {
        Debug.Log("load play menu");
        SceneManager.LoadScene("PlayMenu");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LoadGame");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Application");
    }
}
