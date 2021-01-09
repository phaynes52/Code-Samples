using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform mainboy;
    public Transform family;
    public GameObject panel;
    public UnityEvent stop;
    private float dist;

    private bool started = false;

    void Start()
    {
        //gameObject panel = gameObject.GetComponent("Panel");
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
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
