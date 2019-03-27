using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTrigger : MonoBehaviour
{
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        gameController.StartTheGame();
    }
}
