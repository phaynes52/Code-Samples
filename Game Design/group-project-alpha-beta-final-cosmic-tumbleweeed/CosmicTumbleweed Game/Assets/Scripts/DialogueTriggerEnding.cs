using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTriggerEnding : MonoBehaviour
{
    public List<DialogueSpecial> dialogue;
    public DialogueManagerEnding manager;
    public Transform mainboy;
    public Transform family;
    public GameObject panel;
    public UnityEvent stop;
    private float dist;

    private bool started = false;

    void Start()
    {

    }

    void Update()
    {

        dist = Mathf.Pow(mainboy.position.x - family.position.x, 2);
        dist += Mathf.Pow(mainboy.position.y - family.position.y, 2);
        dist = Mathf.Sqrt(dist);

        if( dist < 2 && !started)
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
