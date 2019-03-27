using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 3f;
    public float leftSideXPosition = -56f;
    public float rightSideXPosition = -28.88f;
    private bool isPlatformMovingRight = true;

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < leftSideXPosition)
            isPlatformMovingRight = true;
        if(this.transform.position.x > rightSideXPosition)
            isPlatformMovingRight = false;

        if (isPlatformMovingRight)
            this.transform.position = new Vector2(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y);
        else
            this.transform.position = new Vector2(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y);
    }
}
