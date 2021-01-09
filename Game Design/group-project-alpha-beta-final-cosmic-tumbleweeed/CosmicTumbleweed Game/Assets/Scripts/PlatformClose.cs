using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformClose : MonoBehaviour
{
    public Animator animator;
    SpriteRenderer sprite;
    private bool closed;
    private bool closing;
    public float delay;
    public bool vertical;
    private float newcoord;
    public GameObject center;
    public float closeSpeed;
    bool stop;

    // Coroutine for destroying platforms
    private IEnumerator close(){
        yield return new WaitForSeconds(delay);
        closing = true;
    }

    public void onEnter(){
        StartCoroutine(close());
    }


    void Start()
    {
        closing = false;
        stop = false;
    }

    private void Awake(){
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Debris")){
            stop = true;
        }
    }

    void Update()
    {
        if(closing){
            if (vertical){
                newcoord = Mathf.Lerp(transform.position.x, center.transform.position.x, closeSpeed);
                transform.position = new Vector3(newcoord, transform.position.y, transform.position.z); 
            } 
            else{
                newcoord = Mathf.Lerp(transform.position.y, center.transform.position.y, closeSpeed);
                transform.position = new Vector3( transform.position.x, newcoord, transform.position.z); 
            }
        }
    }
}
