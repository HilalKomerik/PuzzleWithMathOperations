using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startCVG, exitCVG;

    private void Start()
    {
        FadeQuit();
    }
    void FadeQuit()
    {
        startCVG.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        exitCVG.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGameLevel()
    {
        SceneManager.LoadScene("SearchMenu");
    }

}
