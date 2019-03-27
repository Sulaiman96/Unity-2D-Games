using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVerticalPlatform : MonoBehaviour
{
    public float speed = 3f;
    public float TopYPosition = -10f;
    public float BottomYPosition = -19.63f;
    private bool isPlatformMovingUp = true;

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < BottomYPosition)
            isPlatformMovingUp = true;
        if (this.transform.position.y > TopYPosition)
            isPlatformMovingUp = false;

        if (isPlatformMovingUp)
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime);
        else
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - speed * Time.deltaTime);
    }
}

