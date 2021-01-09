using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OscillatePlatform : MonoBehaviour
{
    public Animator animator;
    public bool left;
    public bool vertical;
    private float xstart;
    private float xstop;
    private float ystart;
    private float ystop;
    public float dist;
    public float moveDist;
    private float newcoord;
    public float offSet;
    private float yuplimit;
    private float ydownlimit;
    private float xleftlimit;
    private float xrightlimit;


    private void Awake(){
        xstart = transform.position.x - dist + offSet;
        xstop = transform.position.x + dist + offSet;
        ystart = transform.position.y - dist + offSet;
        ystop = transform.position.y + dist + offSet;
        ydownlimit = transform.position.y - dist + 0.2f;
        yuplimit = transform.position.y + dist - 0.2f;
        xleftlimit = transform.position.x - dist + 0.2f;
        xrightlimit = transform.position.x + dist - 0.2f;


        transform.position = new Vector3(transform.position.x + offSet, transform.position.y, transform.position.z); 
    }



    void Update()
    {
        if (!vertical){
            if (left){
                newcoord = transform.position.x - moveDist;
                transform.position = new Vector3(newcoord, transform.position.y, transform.position.z); 
            }
            if (!left){
                newcoord = transform.position.x + moveDist;
                transform.position = new Vector3(newcoord, transform.position.y, transform.position.z); 
            } 
            if (transform.position.x < xleftlimit){
                left = false;
            }
            else if (transform.position.x > xrightlimit){
                left = true;
            }
        }
        if (vertical){
            if (left){
                newcoord = transform.position.y - moveDist;
                transform.position = new Vector3(transform.position.x, newcoord, transform.position.z); 
            }
            if (!left){
                newcoord = transform.position.y + moveDist;
                transform.position = new Vector3(transform.position.x, newcoord, transform.position.z); 
            } 
            if (transform.position.y > yuplimit){
                left = true;
            }
            else if (transform.position.y < ydownlimit){
                left = false;
            }
        } 
    }
}
