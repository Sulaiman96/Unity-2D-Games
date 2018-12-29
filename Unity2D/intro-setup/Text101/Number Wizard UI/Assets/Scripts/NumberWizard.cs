using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberWizard : MonoBehaviour {

	// Use this for initialization

    [SerializeField] int maxValue;
    [SerializeField] int lowestValue;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;

    private void Start()
    {
        StartGame();
    }

    void StartGame(){
        NextGuess();
    }

    public void OnPressHigher(){
        lowestValue = guess;
        NextGuess();
    }

    public void OnPressLower(){
        maxValue = guess - 1;
        NextGuess();
    }

    void NextGuess(){
        guess = Random.Range(lowestValue, maxValue +1);
        guessText.text = guess.ToString();
    }

}
