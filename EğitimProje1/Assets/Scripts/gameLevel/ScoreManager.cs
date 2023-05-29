using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int totalScore;
    private int increasingScore;

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        scoreText.text = totalScore.ToString(); 
    }

    public void Increase(string difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case "simple":
                increasingScore = 5;
                break;

            case "middle":
                increasingScore = 10;
                break;

            case "hard":
                increasingScore = 15;
                break;
        }

        totalScore += increasingScore;

        scoreText.text = totalScore.ToString();
    }
}
