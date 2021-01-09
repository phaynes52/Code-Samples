using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClosePath : MonoBehaviour
{

    
    private IEnumerator open(){
        this.gameObject.SetActive(true);
        return null;
    }

    public void onEnter(){
        StartCoroutine(open());
    }
}
