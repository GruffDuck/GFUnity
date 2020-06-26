using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Credit;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void CreditMenu()
    {
        Menu.SetActive(false);
        Credit.SetActive(true);
    }
    public void Back()
    {
        Menu.SetActive(true);
        Credit.SetActive(false);
    }
}

