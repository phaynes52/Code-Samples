using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Following tutorial from https://www.youtube.com/watch?v=zit45k6CUMk

    private float width, startPosition;
    public GameObject cam;
    public float parallaxEffect;
    
    void Start()
    {
        startPosition = transform.position.x;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * ( 1 - parallaxEffect) + 5);
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosition + dist, transform.position[1], transform.position[2]);

        if (temp > startPosition + width) startPosition += width;
        else if (temp < startPosition - width) startPosition -= width;
    }
}
