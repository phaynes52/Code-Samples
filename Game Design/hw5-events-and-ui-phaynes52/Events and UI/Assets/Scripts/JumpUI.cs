using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class JumpUI : MonoBehaviour
{
    private TextMeshProUGUI jumpCount;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateJumpUI (int count)
    {
        jumpCount = GetComponent<TextMeshProUGUI>();
        jumpCount.SetText(count.ToString());   
    }

}
