using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class Lightning : MonoBehaviour
{
    public Light2D lightning;
    public UnityEvent storming;

    public float min;
    public float max;
    public float timer;

    void Start ()
    {
        timer = Random.Range(min, max);
    }

    void Update ()
    {
        FlickerLight();
    }

    void FlickerLight ()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            
        }

        if(timer<=0)
        {
            lightning.enabled = !lightning.enabled;
            timer = Random.Range(min, max);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        storming.Invoke();
        SoundManagerScript.PlaySound("lightning");
    }

}