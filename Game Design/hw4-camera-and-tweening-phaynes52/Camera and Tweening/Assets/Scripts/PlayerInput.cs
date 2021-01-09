using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
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
        //Replace these with player input
        x = 0;
        jumpDown = false;
        jumpStay = false;
        die = false;

        //Calls Move every physics frame.
        controller.Move(x, jumpDown, jumpStay);

        if (die) controller.Die();
    }
}
