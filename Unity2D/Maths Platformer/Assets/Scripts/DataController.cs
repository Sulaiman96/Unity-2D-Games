using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    [SerializeField] RoundData[] allRoundData; //can extend for multiple rounds.
    public GameObject instructionPanel;
    public GameObject menuPanel;

    // Start is called before the first frame update

    public void PlayGame()
    {
        SceneManager.LoadScene("Main Map");
    }

    public RoundData GetCurrentRoundData() {
        return allRoundData[0];
    }

    public void InstructionPage()
    {
        menuPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void goingBack()
    {
        menuPanel.SetActive(true);
        instructionPanel.SetActive(false);
    }


}
