using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnStartBtnClicked()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnQuitBtnClicked()
    {
        Application.Quit();
    }
}
