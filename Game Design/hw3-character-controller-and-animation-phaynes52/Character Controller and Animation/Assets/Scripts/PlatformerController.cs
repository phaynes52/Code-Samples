using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    // Stats such as movement speed should go here. 
    // Make them public or give them a [SerializeField] attribute to make them appear in the Inspector window.
    #region VARIABLES
    public float moveSpeed = 4f;
    private Vector3 horizontal = new Vector3(1,0,0);
    private Vector3 vertical = new Vector3(0, -1 ,0);
    #endregion

    //All needed references to sibling components on this GameObject. These can be seen and manually set in the Inspector
    #region COMPONENT REFERENCES
    public new Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Vector2 thrust = new Vector2(0,8);
    #endregion

    /// <summary>
    /// Controls all movement for the player. jumpDown and jumpStay both exist if you want to make a tighter jump.
    /// If you don't intend to do this, you can ignore jumpStay and just use jumpDown.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="jumpDown"></param>
    /// <param name="jumpStay"></param>
    public void Move (float x, bool jumpDown, bool jumpStay = false)
    {
        if (x == 1) {
            spriteRenderer.flipX = false; 
            if (transform.position[1] < -2.138) animator.SetBool("LeftRight", true);
        }

        else if (x == -1) {
            spriteRenderer.flipX = true; 
            if (transform.position[1] < -2.138) animator.SetBool("LeftRight", true);
        }

        else if (x == 0) {
            animator.SetBool("LeftRight", false);
        }

        horizontal.x = x;
        transform.Translate(horizontal * moveSpeed * Time.deltaTime);
        if (jumpDown && transform.position[1] > -2.13);
        else if (jumpDown) { 
            animator.SetBool("Down", false);
            animator.SetTrigger("Jump");
            animator.SetBool("LeftRight", false);
            rigidbody.AddForce(thrust, ForceMode2D.Impulse);
        }
        
        if(rigidbody.velocity.y <= 0 && !animator.GetBool("Down")) {
            animator.SetBool("Down", true);
        }
        if (transform.position[1] > -2) animator.SetBool("Ground", false);
        if (transform.position[1] < -2) animator.SetBool("Ground", true);
    }

    /// <summary>
    /// Plays the death animation and disables all player input. Death animation should not repeat.
    /// </summary>
    public void Die()
    {
        animator.SetTrigger("Hit");
    }


    // Special built in function that gets called per collision on this object.
    // The "other" passed in is the object it collided with.
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // Your code here
    }
}
