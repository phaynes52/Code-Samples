using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region VARIABLES
    float x;
    bool jumpDown, jumpStay;
    bool die;
    public float moveSpeed = 4f;
    private bool Adown;
    private bool Ddown;
    private bool SpaceDown;
    private bool dead;
    
    #endregion

    // Can be seen and manually set in the Inspector
    #region COMPONENT REFERENCES
    public PlatformerController controller = null;
    public GameObject enemy;
    #endregion

    // Called once per physics frame (different than render frame)
    // FixedUpdate() is typically used instead of Update() for anything involving rigidbodies/physics
    private void FixedUpdate()
    {
        //Replace these with player input
        jumpDown = (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)) && !die;
        jumpStay = false;
        die = (GetComponent<Collider2D>().IsTouching(enemy.GetComponent<Collider2D>()) && dead == false || transform.position.y < -4);
        Adown = Input.GetKey(KeyCode.A);
        Ddown = Input.GetKey(KeyCode.D);
        if (Adown && Ddown) x = 0;
        else if (Adown && !dead) x = -1;
        else if (Ddown && !dead) x = 1;
        else x = 0;

        //Calls Move every physics frame.
        controller.Move(x, jumpDown, jumpStay);
        if (die) {
            dead = true;
            die = false;
            controller.Die();
        }
    }
}
