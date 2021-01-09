using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    // Stats such as movement speed should go here. 
    // Make them public or give them a [SerializeField] attribute to make them appear in the Inspector window.
    #region VARIABLES
    //STATS HERE    
    #endregion

    //All needed references to sibling components on this GameObject
    #region COMPONENT REFERENCES
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
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

    }

    /// <summary>
    /// Plays the death animation and disables all player input. Death animation should not repeat.
    /// </summary>
    public void Die()
    {

    }
}
