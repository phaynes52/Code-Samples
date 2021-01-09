using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTriggerSpecial : MonoBehaviour
{
    public List<DialogueSpecial> dialogue;
    public DialogueManagerSpecial manager;
    //public DialogueSpecial dialogue;
    public Transform mainboy;
    public Transform family;
    public GameObject panel;
    public UnityEvent stop;
    private float dist;
    public bool alreadyRead;

    private bool started = false;

    public void setRead(){
        alreadyRead = true;
    }

    void Start()
    {

    }

    void Update()
    {

        dist = Mathf.Pow(mainboy.position.x - family.position.x, 2);
        dist += Mathf.Pow(mainboy.position.y - family.position.y, 2);
        dist = Mathf.Sqrt(dist);

        if( dist < 2 && !started && !alreadyRead)
        {
            TriggerDialogue();
            started = true;
            stop.Invoke();
        }

    }
    public void TriggerDialogue ()
    {
        panel.SetActive(true);
        foreach(DialogueSpecial d in dialogue)
        {
            manager.SetDialogue(d);
        }
        manager.StartDialogue();
    }
}
