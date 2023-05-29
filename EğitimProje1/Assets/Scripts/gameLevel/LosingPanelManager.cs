using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosingPanelManager : MonoBehaviour
{
    public void StartAgain()
    {
        SceneManager.LoadScene("gameLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menuLevel");
    }
}
