using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject registerMenu;
    public GameObject loginMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void RegisterMenu()
    {
        mainMenu.SetActive(false);
        registerMenu.SetActive(true);
    }

    public void LoginMenu()
    {
        mainMenu.SetActive(false);
        loginMenu.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        registerMenu.SetActive(false);
        loginMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
