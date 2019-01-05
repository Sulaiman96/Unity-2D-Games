using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] CharacterController2D controller;
    float horizontalMove = 0f;
    [SerializeField] float runSpeed = 1f;
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //gives a value of -1 to 1 depending on which key is pressed. 
	}

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false); //Time.fixedDeltaTime makes sure our character movement speed is consistent. 
    }
}
