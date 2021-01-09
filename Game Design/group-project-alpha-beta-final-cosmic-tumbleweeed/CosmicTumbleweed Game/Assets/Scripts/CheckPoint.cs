using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    public Transform player;
    private GameObject check;
    //private bool doNotTrigger;
    public UnityEvent stopDialogue;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        // if (doNotTrigger){
        //     stopDialogue.Invoke();
        // }


    }
    // Start is called before the first frame update
    public void updateCheckpoint()
    {
        gm.lastCheckPointPos = player.position;
        gm.lastCheckPointPos.x += 0.5f;
        gm.lastCheckPointPos.y += 0.5f;
        check = gm.recentCheck.transform.GetChild(0).gameObject;
        check.SetActive(true);
        //doNotTrigger = true;
        SoundManagerScript.PlaySound("checkpoint");
        
    }
}
