using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffectSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (cam.transform.position.x * parallaxEffectSpeed);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
