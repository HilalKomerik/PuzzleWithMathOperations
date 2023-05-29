using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SearchMenuManager : MonoBehaviour
{
    public int level=1;

    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Transform levelArrowImage1;

    [SerializeField] 
    private GameObject levelArrow1;

    [SerializeField]
    private Transform levelArrowImage2;

    [SerializeField]
    private GameObject levelArrow2;

    [SerializeField]
    private Transform levelArrowImage3;

    [SerializeField]
    private GameObject levelArrow3;

    [SerializeField]
    private Transform levelArrowImage4;

    [SerializeField]
    private GameObject levelArrow4;

    void Start()
    {
        levelText.text = level.ToString();
        levelValue(level);
    }
    public void Button1()
    {
        SceneManager.LoadScene("gameLevel");
    }

    public void levelValue(int lev)
    {
        switch (lev)
        {
            case 1:
                levelArrow1.transform.DOMove(levelArrowImage1.position, 3);
                break;

            case 2:
                levelArrow2.transform.DOMove(levelArrowImage2.position, 3);
                break;

            case 3:
                levelArrow3.transform.DOMove(levelArrowImage3.position, 3);
                break;

            case 4:
                levelArrow4.transform.DOMove(levelArrowImage4.position, 3);
                break;
        }

        levelText.text = level.ToString();
    }

}
