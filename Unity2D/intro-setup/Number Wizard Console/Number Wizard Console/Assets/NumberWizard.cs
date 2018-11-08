using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int maxValue = 1000;
        int lowestValue = 1;
        int guess = 0;

        Debug.Log("Welcome to number wizard, yo");
        Debug.Log("Please think of a number.");
        Debug.Log("highest number you can pick is: " + maxValue);
        Debug.Log("lowest number you can pick is: " + lowestValue);
        Debug.Log("Tell me if your number is higher or lower than: " + guess);
        Debug.Log("Please use your arrow keys, Push-up = Higher, Push-down = Lower, Enter = Correct");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
           Debug.Log("Up arrow has been pressed.");
        } else if (Input.GetKeyDown(KeyCode.DownArrow)){
            Debug.Log("Down arrow has been pressed.");
        }else if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("Enter key has been pressed.");
        }

	}
}
