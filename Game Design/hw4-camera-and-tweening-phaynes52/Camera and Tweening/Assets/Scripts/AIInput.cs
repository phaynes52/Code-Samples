using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    #region VARIABLES
    float x;
    bool jumpDown, jumpStay;
    bool die;
    #endregion

    #region COMPONENT REFERENCES
    [SerializeField] private PlatformerController controller = null;
    #endregion

    private void FixedUpdate()
    {
        //Replace these with AI input. It should wander until the player gets near, then chase the player.
        x = 0;
        jumpDown = false;
        jumpStay = false;
        die = false;

        //Calls Move every physics frame.
        controller.Move(x, jumpDown, jumpStay);

        if (die) controller.Die();
    }
}
