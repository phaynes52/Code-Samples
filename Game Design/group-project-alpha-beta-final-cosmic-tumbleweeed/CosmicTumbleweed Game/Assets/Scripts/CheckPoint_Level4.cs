using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint_Level4 : MonoBehaviour
{
    private GameMaster gm;
    public Transform player;
    private GameObject check;
    public int checkNum;
    public UnityEvent close_platform;
    public UnityEvent ground_pound;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }
    // Start is called before the first frame update
    public void updateCheckpoint()
    {
        gm.lastCheckPointPos = player.position;
       // gm.lastCheckPointPos.x += 0f;
        //gm.lastCheckPointPos.y += 0.1f;
        check = gm.recentCheck.transform.GetChild(0).gameObject;
        check.SetActive(true);
    
        SoundManagerScript.PlaySound("checkpoint");        

        if(checkNum >= 1)
        {
            close_platform.Invoke();
        }
        
        if(gm.groundPound)
        {
            ground_pound.Invoke();
        }
    }
}
