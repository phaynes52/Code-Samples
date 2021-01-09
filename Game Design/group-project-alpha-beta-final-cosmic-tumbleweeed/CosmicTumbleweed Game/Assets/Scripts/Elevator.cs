using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Elevator : MonoBehaviour
{

    private bool goingUp;
    public GameObject center;
    public float moveDist;
    private float newcoord;
    public bool horizontal;

    private void Awake(){
        goingUp = false;
    }

    private IEnumerator up(){
        goingUp = true;
        return null;
    }

    public void onEnter(){
        StartCoroutine(up());
    }



    void Update()
    {
        if (goingUp){
            if (!horizontal) {
                newcoord = transform.position.y + moveDist;
                transform.position = new Vector3(transform.position.x, newcoord, transform.position.z); 
                if (transform.position.y >= center.transform.position.y) goingUp = false;
            }
            else {
                newcoord = transform.position.x + moveDist;
                transform.position = new Vector3(newcoord, transform.position.y, transform.position.z); 
                if (transform.position.x >= center.transform.position.x) goingUp = false;
            }
        } 
    }
}
