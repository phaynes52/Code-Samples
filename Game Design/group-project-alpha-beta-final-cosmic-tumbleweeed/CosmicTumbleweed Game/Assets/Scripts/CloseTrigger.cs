using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CloseTrigger : MonoBehaviour
{

    public UnityEvent platformClose;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Player")){
            platformClose.Invoke();
        }
    }

}