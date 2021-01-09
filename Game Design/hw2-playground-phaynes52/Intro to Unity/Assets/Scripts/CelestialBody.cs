using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    #region VARIABLES
    public GameObject target;
    public float rotationSpeed;
    public bool planet;
    public Vector3 relativeDistance = Vector3.zero;

    

    #endregion

    // Start is called before the first frame update
    private void Start()
    { 
         if(target != null) 
         {
             relativeDistance = transform.position - target.transform.position;
         }
    }

    // Update is called once per frame
    private void Update()
    {
        if (planet) {
            transform.RotateAround(target.transform.position, new Vector3(0,0,1), rotationSpeed * Time.deltaTime);
        }
    }

    //Moon orbit taken from https://answers.unity.com/questions/433791/rotate-object-around-moving-object.html
     void Orbit()
     {
        // $$anonymous$$eep us at the last known relative position
        transform.position = target.transform.position + relativeDistance;
        transform.RotateAround(target.transform.position, new Vector3(0,0,1), rotationSpeed * Time.deltaTime);
        relativeDistance = transform.position - target.transform.position;
     }

    
    private void LateUpdate() {

        if (planet == false){
            Orbit();
        }
    }
}