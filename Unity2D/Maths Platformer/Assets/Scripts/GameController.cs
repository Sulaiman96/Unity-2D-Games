using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    #region Variables
    public TMP_Text questionDisplayText;
    public TMP_Text scoreDisplayText;
    public TMP_Text timeRemainingDisplayText;
    public TMP_Text coinText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public GameObject wallBlock;
    public GameObject questionTrigger;
    public int amountOfCoins = 25;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int coinCount;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    #endregion
    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        coinCount = 0;
    }

    void Update()
    {
        SetCountText();

        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();
            if(timeRemaining <= 0f)
            {
                EndRound();
            }
        }
    }
    #region Public Functions
    public void StartTheGame()     {
        //Enable the GUI
        scoreDisplayText.GetComponent<TextMeshProUGUI>().enabled = true;
        timeRemainingDisplayText.GetComponent<TextMeshProUGUI>().enabled = true;
        questionDisplay.SetActive(true);
         //Reset the score and its text         playerScore = 0;         scoreDisplayText.text = "Questions Correctly Answered: " + playerScore.ToString();         //Reset the question index so we start from the start again         questionIndex = 0;         currentRoundData = dataController.GetCurrentRoundData();         questionPool = currentRoundData.questions;         ShowQuestion();          //reset the time remaining and start the counter.         timeRemaining = currentRoundData.timeLimitInSeconds;         UpdateTimeRemainingDisplay();         isRoundActive = true;     }

    public void SetCountText()
    {         coinText.text = ": " + coinCount.ToString();         if (coinCount >= amountOfCoins)
        {             Debug.Log("You win the game");         }     }      public void Pickup()
    {         coinCount++;     }
    //checks whether the answer that is pressed is correct or not.
    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Questions Correctly Answered: " + playerScore.ToString();
        }
        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        isRoundActive = false;

        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
        //Change this to display a panel depending on the answer.
        if (playerScore >= 3) //give them the ticket.
        {
            wallBlock.SetActive(false);
        }
        else
        {
            questionTrigger.SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(false);
        scoreDisplayText.GetComponent<TextMeshProUGUI>().enabled = false;
        timeRemainingDisplayText.GetComponent<TextMeshProUGUI>().enabled = false;
    }
    #endregion

    #region Private Functions
    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons(); //removing old answers so that we can display the new questions.
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText; //displaying the question

        for (int i = 0; i < questionData.answers.Length; i++) //displaying the buttons
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    //used to remove buttons
    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }
    #endregion
}
