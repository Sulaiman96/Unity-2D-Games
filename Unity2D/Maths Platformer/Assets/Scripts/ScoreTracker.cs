using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    private int totalQuestion;
    private int totalCorrectAnswer;
    private int scorePercentage;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        totalQuestion = 0;
        totalCorrectAnswer = 0;
        scorePercentage = 0;
    }

    public void AddToTotalQuestion()
    {
        totalQuestion += 6;
    }

    public void AddToTotalAnswers()
    {
        totalCorrectAnswer++;
    }

    public int CalculatingScorePercentage(int totalQuestion, int totalCorrectAnswer)
    {
        return scorePercentage = 100 * (totalCorrectAnswer / totalQuestion);
    }

    public void PrintValues()
    {
        Debug.Log("Total Questions: " + totalQuestion);
        Debug.Log("Total Questions Answered Correctly: " + totalCorrectAnswer);
        CalculatingScorePercentage(totalQuestion, totalCorrectAnswer);
        Debug.Log("ScorePercentage: " + scorePercentage);
    }
}
