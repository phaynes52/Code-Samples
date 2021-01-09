using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    #region VARIABLES
    float x = -1;
    bool jumpDown, jumpStay;
    bool die;
    private bool Adown;
    private bool Ddown;
    private bool SpaceDown;
    private float seperation;
    private bool closeEnough;
    private bool dead = false;
    private float timer = 3f;
    #endregion

    // Can be seen and manually set in the Inspector
    #region COMPONENT REFERENCES
    public PlatformerController controller = null;
    public GameObject player;
    #endregion

    // Called once per physics frame (different than render frame)
    // FixedUpdate() is typically used instead of Update() for anything involving rigidbodies/physics
    private void FixedUpdate()
    {
        seperation = Mathf.Abs(transform.position[0] - player.transform.position[0]);
        closeEnough = (seperation < 5);

        if (GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>())) {
            x = 0;
            dead = true;
        }

        if (transform.position.x < -9.75 || transform.position.x > 9.75) {
            x = -x;
            timer = Random.Range(1f, 3f);
        }

        else if (closeEnough && dead == false) {
            if ((transform.position[0] - player.transform.position[0]) < 0 ) x = 1;
            else if ((transform.position[0] - player.transform.position[0]) > 0 ) x = -1;
        }

        else if (closeEnough == false) {
            //Taken from https://answers.unity.com/questions/770857/whats-the-most-efficient-way-to-time-events.html
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                x = -x;
                timer = Random.Range(1.5f, 4f);
            }
        };

        //Calls Move every physics frame.
        controller.Move(x, jumpDown, jumpStay);
        if (die) controller.Die();
    }
}
