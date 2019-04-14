using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(Vector2.up* 8, ForceMode2D.Impulse); 
    }
}
