using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int>
{
}

public class JumpBox : MonoBehaviour
{
    #region VARIABLES
    private int jumpCount;
    public IntEvent onJump;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.up * 20f;
            jumpCount += 1;
            onJump.Invoke(jumpCount);
        }
    }
}
