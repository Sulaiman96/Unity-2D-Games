using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCoinSound : MonoBehaviour
{
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audio.Play();
    }

}
