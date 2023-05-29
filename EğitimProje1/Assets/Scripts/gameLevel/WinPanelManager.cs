using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelManager : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("gameLevel2");
    }
    public void StartAgain()
    {
        SceneManager.LoadScene("gameLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SearchMenu");
    }
}
