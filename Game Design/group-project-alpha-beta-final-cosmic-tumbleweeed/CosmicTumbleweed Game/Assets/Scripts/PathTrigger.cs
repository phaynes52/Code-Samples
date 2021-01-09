using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class IntEvent : UnityEvent<int>
{
}

public class PathTrigger : MonoBehaviour
{

    public IntEvent platformClose;
    public int quadrant;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Player")){
            platformClose.Invoke(quadrant);
        }
    }

}