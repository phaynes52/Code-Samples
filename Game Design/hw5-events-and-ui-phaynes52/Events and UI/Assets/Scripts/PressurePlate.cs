using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public Transform button;
    public bool pressed;
    public GameObject door;

    //Your events here

    public UnityEvent press;
    public UnityEvent unpress;


    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.localPosition.y < 0.5 && !pressed)
        {
            pressed = true;
            Pressed();
        }
        if (button.localPosition.y > 0.5 && pressed)
        {
            pressed = false;
            Unpressed();
        }
    }

    private void Pressed()
    {
        press.Invoke();
    }

    private void Unpressed()
    {
        unpress.Invoke();
    }
}
