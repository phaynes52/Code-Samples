using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    private Vector3 vertical = new Vector3(0,1,0);
    private Vector3 horizontal = new Vector3(1,0,0);
    private Vector3 depth = new Vector3(0,0,1);
    public float moveSpeed = 4f;
    public float rotateSpeed = 180f;
    private Vector3 shrink = new Vector3(0.99f, 0.99f, 1f);
    private Vector3 grow = new Vector3(1.01f, 1.01f, 1f);
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        // Your code here
    }

    // Update is called once per frame
    private void Update()
    {
        bool Adown = Input.GetKey(KeyCode.A);
        bool Ddown = Input.GetKey(KeyCode.D);
        bool Sdown = Input.GetKey(KeyCode.S);
        bool Wdown = Input.GetKey(KeyCode.W);
        bool Qdown = Input.GetKey(KeyCode.Q);
        bool Edown = Input.GetKey(KeyCode.E);
        bool Zdown = Input.GetKey(KeyCode.Z);
        bool Xdown = Input.GetKey(KeyCode.X);

        if(Adown && Ddown) {
        }

        else if (Ddown) {
            transform.Translate(horizontal * moveSpeed * Time.deltaTime);
        }

        else if (Adown) {
            transform.Translate(-horizontal * moveSpeed * Time.deltaTime);
        }

        if (Wdown && Sdown) {
        }

        else if (Wdown) {
            transform.Translate(vertical * moveSpeed * Time.deltaTime);
        }

        else if (Sdown) {
            transform.Translate(-vertical * moveSpeed * Time.deltaTime);
        }


        if (Qdown && Edown) {
        }

        else if (Qdown) {
            transform.localScale = Vector3.Scale(transform.localScale,shrink);
        }

        else if (Edown) {
            transform.localScale = Vector3.Scale(transform.localScale,grow);
        }

        if (Zdown && Xdown) {
        }

        else if (Zdown) {
            transform.Rotate(depth * rotateSpeed * Time.deltaTime);
        }

        else if (Xdown) {
            transform.Rotate(-depth * rotateSpeed * Time.deltaTime);

        }
    }
}
