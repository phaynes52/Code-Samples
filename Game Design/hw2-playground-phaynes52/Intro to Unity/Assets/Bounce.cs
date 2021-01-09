using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
	public bool shrinking = true;
    public Vector3 shrink = new Vector3(1f, 0.999f, 1f);
    public Vector3 grow = new Vector3(1f, 1.001f, 1f);
  	public float yScale; 

    // Start is called before the first frame update
    void Start()
    {
        yScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

    	if (shrinking == true)
    	{

    		transform.localScale = Vector3.Scale(transform.localScale,shrink);

    		if (transform.localScale.y < 0.025)
    		{
    			shrinking = false;
    		}

    	}

    	else if (shrinking == false)
    	{

    		transform.localScale = Vector3.Scale(transform.localScale,grow);

    		if (transform.localScale.y > yScale) 
    		{
    			shrinking = true;
    		}

    	}
    }
}
