using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BannerHelp : MonoBehaviour
{
    public GameObject helpText; 

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        helpText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        helpText.SetActive(false);
    }
}
