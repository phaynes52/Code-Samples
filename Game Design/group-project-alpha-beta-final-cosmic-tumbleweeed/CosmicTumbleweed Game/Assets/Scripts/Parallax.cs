using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Following tutorial from https://www.youtube.com/watch?v=zit45k6CUMk

    private float width, startPosition;
    public GameObject cam;
    public float parallaxEffect;
    public bool cloud;
    private float lastx;
    private float diff;
    private float currentx;
    
    void Start()
    {
        startPosition = transform.position.x;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        lastx = cam.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentx = cam.transform.position.x;

        if (cloud == true){
            if (currentx - width > transform.position.x) {
                transform.Translate(new Vector3(width,0,0));
            }
            else if (currentx + width < transform.position.x) {
                transform.Translate(new Vector3(-1*width,0,0));
            }
        }

        float temp = (currentx * ( 1 - parallaxEffect));
        float dist = (currentx * parallaxEffect);

        diff = 2*(currentx - lastx)/3;

        if (cloud == false) transform.position = new Vector3(startPosition + dist, transform.position[1], transform.position[2]);

        if (cloud == true){
            if (diff > 0) transform.Translate(new Vector3(-1 * Time.deltaTime - diff, 0, 0));
            else transform.Translate(Vector3.left * Time.deltaTime);
        };

        if (temp > startPosition + (2*width)) startPosition += width;
        else if (temp < startPosition - (2*width)) startPosition -= width;

        if (cloud == true){
            if (currentx - width > transform.position.x) {
                transform.Translate(new Vector3(width,0,0));
            }
            else if (currentx + width < transform.position.x) {
                transform.Translate(new Vector3(-1*width,0,0));
            }
        }

        lastx = cam.transform.position.x;
    }
}
