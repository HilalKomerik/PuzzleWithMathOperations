using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab;

    [SerializeField]
    private Transform squarePaneli;

    [SerializeField]
    private Text questionText;

    private GameObject[] squareDizi = new GameObject[25];

    [SerializeField]
    private Transform questionPanel;


    [SerializeField]
    private Sprite[] squareSprite;

    List<int> sectionValuesList = new List<int>();

    int dividing, divisor;// dividing = bölünen divisor = bölen
    int resultBox;
    int correctResult;

    int buttonValue;

    int remainderHeart;

    bool clickButton;

    string difficultyDegree;

    RemainderLifeManager remainderLifeManager;
    ScoreManager scoreManager;
    SearchMenuManager searchMenuManager;

    GameObject availableScore;

    [SerializeField]
    private GameObject losingPanel;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    AudioSource audioSource;

    public AudioClip buttonSound;

    private void Awake()
    {
        remainderHeart = 3;

        audioSource = GetComponent<AudioSource>();

        losingPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        winPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        remainderLifeManager = Object.FindObjectOfType<RemainderLifeManager>();
        scoreManager = Object.FindObjectOfType<ScoreManager>();
        searchMenuManager = Object.FindObjectOfType<SearchMenuManager>();

        remainderLifeManager.CheckRemainderLife(remainderHeart);
    }

    void Start()
    {
        clickButton = false;

        questionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        CreateSquare();
    }

    public void CreateSquare()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject square = Instantiate(squarePrefab, squarePaneli);
            square.transform.GetChild(1).GetComponent<Image>().sprite = squareSprite[i];
            square.transform.GetComponent<Button>().onClick.AddListener(() => PushButton());
            squareDizi[i] = square;
        }

        ValuesText();

        StartCoroutine(DoFadeRoutine());
        Invoke("QuestionTextOpen", 2f);
    }
    void PushButton()
    {
        if (clickButton)
        {
            audioSource.PlayOneShot(buttonSound); // Bir kez çalýþtýr.
            buttonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);

            availableScore = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            CheckResult();
        }
    }

    void CheckResult()
    {
        if (buttonValue== correctResult)
        {
            availableScore.transform.GetChild(1).GetComponent<Image>().enabled = true;
            availableScore.transform.GetChild(0).GetComponent<Text>().text = "";
            availableScore.transform.GetComponent<Button>().interactable = false;

            scoreManager.Increase(difficultyDegree);

            sectionValuesList.RemoveAt(resultBox);

            if (sectionValuesList.Count>0)
            {
                QuestionTextOpen();
            }
            else
            {
                clickButton = false;
                winPanel.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
                searchMenuManager.level++;

            }
        }
        else
        {
            remainderHeart--;
            remainderLifeManager.CheckRemainderLife(remainderHeart);
        }

        if (remainderHeart<=0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        clickButton = false;
        losingPanel.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    IEnumerator DoFadeRoutine()
    {
        foreach (var square in squareDizi)
        {
            square.GetComponent<CanvasGroup>().DOFade(1, 0.2f);

            yield return new WaitForSeconds(0.07f);
        }
    }
    void ValuesText()
    {
        foreach (var square in squareDizi)
        {
            int randomValue = Random.Range(1, 13);
            sectionValuesList.Add(randomValue);
            square.transform.GetChild(0).GetComponent<Text>().text = randomValue.ToString();
        }
    }

    void QuestionTextOpen()
    {
        Question();
        clickButton = true;
        questionPanel.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    void Question()
    {
        divisor = Random.Range(2, 11);

        resultBox = Random.Range(0, sectionValuesList.Count);

        correctResult = sectionValuesList[resultBox];

        dividing = divisor * correctResult;

        if (dividing<=40)
        {
            difficultyDegree = "simple";
        }
        else if (dividing>40 && dividing <=80)
        {
            difficultyDegree = "middle";
        }
        else
        {
            difficultyDegree = "middle";
        }

        questionText.text = dividing.ToString() + " : " + divisor.ToString();
    }
}
