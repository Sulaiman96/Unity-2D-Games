using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject {

    [TextArea(10,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;

    public State[] getNextStates(){
        return nextStates;
    }

    public string getStateStory(){
        return storyText;
    }
}
