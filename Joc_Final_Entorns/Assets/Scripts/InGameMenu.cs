using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    public GameObject GameMenu;

    public void ReturnGame()
    {
        Time.timeScale = 1;
        GameMenu.SetActive(false);
        PlayerControl.MenuActive = false;
            
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
