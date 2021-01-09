using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region VARIABLES

    private bool hasCollided = false;
    private Vector3 tmpPos;
    #endregion

    #region COMPONENT REFERENCES
    public Transform player;
    public Rigidbody2D rigidbody;
    private bool withinRange;
    SpriteRenderer sprite;
    BoxCollider2D box;
    PolygonCollider2D poly;
    private bool playedSound;
    #endregion

    private void Start(){
        sprite = GetComponent<SpriteRenderer>();
        if ( GetComponent<BoxCollider2D>() != null){
            box = GetComponent<BoxCollider2D>();
        } else if (GetComponent<PolygonCollider2D>() != null ){
            poly = GetComponent<PolygonCollider2D>();
        }
        playedSound = false;
    }

    private void FixedUpdate()
    {
        withinRange = (Mathf.Abs(transform.position.x - player.position.x) < 5f && (transform.position.y > player.position.y) && (transform.position.y < player.position.y + 20f));

        if( !hasCollided && withinRange) {
            if (!playedSound){
                SoundManagerScript.PlaySound("fallingDebris");
                playedSound = true;
            }
            tmpPos = transform.position;
            tmpPos.x = Mathf.Lerp(transform.position.x, player.position.x, 0.02f);
            transform.position = tmpPos;
            rigidbody.gravityScale = 1f;
        };

        }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Pound")){
            hasCollided = true;
            sprite.enabled = false;
            if (box != null){
                box.enabled = false;
            } else if (poly != null){
                poly.enabled = false;
            }
            
        }
        if (other.gameObject.CompareTag("Player")){
            hasCollided = true;
        }

    }

}