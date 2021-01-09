using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformChange : MonoBehaviour
{
    public int lifeForce;
    public Animator animator;
    SpriteRenderer sprite;
    public bool groundPound;
    public Transform player;
    bool withinRange;
    bool playedSound;

    public UnityEvent delete; // for objects on top of the platform
    PlayerController script;

    // Coroutine for destroying platforms
    private IEnumerator destroy(float sec){
        animator.SetTrigger("crumbling");
        SoundManagerScript.PlaySound("crumble");
        yield return new WaitForSeconds(sec);
        GetComponent<BoxCollider2D>().enabled = false;
        delete.Invoke();
    }

    private void pounded(){
        
        animator.SetTrigger("pounded");
        if (!playedSound){
            SoundManagerScript.PlaySound("crumble");
            playedSound = true;
        }
        delete.Invoke();
    }

    public void OnWin (){
        // trigger animation of platforms deteriorating
        StartCoroutine(destroy(0.5f));
    }
    
    void Crumble(){
        lifeForce -= 1;

        if (lifeForce == 1){ 
            // trigger animation, then change color
            Color newColor = new Color (0.666f, 0.5019f, 0.3058f, 1f);
            sprite.color = newColor;
            SoundManagerScript.PlaySound("step");
        } 
        // once it hits zero, it's getting destroyed!
        if (lifeForce == 0){
            if (script.getPound()){
                pounded();
                GetComponent<BoxCollider2D>().enabled = false;
            } else {
                StartCoroutine(destroy(0.5f));
                SoundManagerScript.PlaySound("crumble");
            }  
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (!groundPound && other.gameObject.CompareTag("Player")){
           Crumble();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (groundPound && script.getPound() == true && other.gameObject.CompareTag("Player")){
            pounded();
        }
    }
    void Start()
    {
        // change all of the pre-crumbled platforms to 1
        // all of the other platforms have a default life force of 2
        if (lifeForce == 0){
            lifeForce = 2;
        }
        playedSound = false;

        script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Awake(){
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {   if (groundPound){
            withinRange = ( (Mathf.Abs(transform.position.x - player.position.x) < 1.0f) && (Mathf.Abs(player.position.y - transform.position.y) < 1.5f));
        }
        if (groundPound && withinRange && script.getPound()){
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
