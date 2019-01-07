using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Demo_GM : MonoBehaviour {



    public static Demo_GM Gm;

    public Image[] UIImage;

    // Use this for initialization
    void Awake () {
        Screen.fullScreen = false;
        Gm = this; // assign object. 
    }
	
	// Update is called once per frame
	void Update () {

        KeyUPDownchange(); // check to see which key is pressed.
    }


    void InitColor()
    {

        for (int i = 0; i < UIImage.Length; i++)
        {
            UIImage[i].color = new Color(255, 255, 255);


        }

    }

    public void KeyUPDownchange()
    {
        // wsad
        if (Input.GetKeyUp(KeyCode.A))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[2].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[3].color = myColor;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[0].color = myColor;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[1].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[2].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[3].color = myColor;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[0].color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[1].color = myColor;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            Color myColor = new Color32(180, 180, 180, 255);

            Demo_GM.Gm.UIImage[4].color = myColor;
        }



        if (Input.GetKeyUp(KeyCode.Space))
        {

            Color myColor = new Color32(255, 255, 255, 255);

            Demo_GM.Gm.UIImage[4].color = myColor;
        }


    }

}
