using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class FirstButton : MonoBehaviour
{
    Button button;

    void OnEnable()
    {
        button = GetComponent<Button>();
        button.Select();
    }
 
 
}