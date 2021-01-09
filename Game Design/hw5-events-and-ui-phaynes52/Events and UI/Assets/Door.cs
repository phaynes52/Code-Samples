using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool opening;
    private bool closing;
    public float smooth;
    public float scaleChange;

    void Start()
    {
    opening = false;
    closing = false;
    smooth = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening == true) {
            scaleChange = Mathf.Lerp(transform.localScale.x, 1f, Time.deltaTime);
            if ((transform.localScale.x + scaleChange) > 1){
                transform.localScale += new Vector3(1-transform.localScale.x,0,0);
            }
            else transform.localScale += new Vector3(scaleChange,0,0);
            if (transform.localScale.x == 1f) opening = false;
        }
        if (closing == true) {
            scaleChange = Mathf.Lerp(transform.localScale.x, 0f, Time.deltaTime);
            if ((transform.localScale.x - scaleChange) > 1){
                transform.localScale -= new Vector3(transform.localScale.x,0,0);
            }
            else transform.localScale -= new Vector3(scaleChange,0,0);
            if (transform.localScale.x == 0f) closing = false;
        }
        
    }

    public void Open()
    {
        opening = true;
    }
    
    public void Close()
    {
        closing = true;
    }
}
