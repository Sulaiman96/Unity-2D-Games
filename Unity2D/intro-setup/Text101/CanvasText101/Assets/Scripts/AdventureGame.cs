using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{

    [SerializeField] Text textComponent; //SerializeField allows us to change this in Unity Inspector.
    [SerializeField] State StartingState;



    State state;
    // Use this for initialization
    void Start()
    {
        state = StartingState;
        textComponent.text = state.getStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageStates();
    }

    private void ManageStates()
    {
        var nextStates = state.getNextStates(); //keeps track of the next state.
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            state = nextStates[0];
        } else if (Input.GetKeyDown(KeyCode.Alpha2)){
            state = nextStates[1];
        }else if (Input.GetKeyDown(KeyCode.Alpha3)){
            state = nextStates[2];
        }else if (Input.GetKeyDown(KeyCode.Alpha4)){
            state = nextStates[3];
        }else
        {
            Debug.Log("Please press number 1-4");
        }
        textComponent.text = state.getStateStory();
    }
}
