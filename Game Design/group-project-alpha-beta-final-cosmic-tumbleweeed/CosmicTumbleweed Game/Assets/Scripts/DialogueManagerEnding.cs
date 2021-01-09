using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueManagerEnding : MonoBehaviour
{
    private Queue<DialogueSpecial> talk;
    public TextMeshProUGUI person;
    public TextMeshProUGUI words;
    public Animator animator;
    public Animator panelAnimator;
    public GameObject exitend;
    public UnityEvent move;
    private bool read = false;
    private bool started = false;
    public bool isEmotional;
    public string character;
    private bool ending;


    //public UnityEvent unlockAbility;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("IsOpen", false);
        exitend.SetActive(false);
        //sentences = new Queue<string>();
        talk = new Queue<DialogueSpecial>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(read && panelAnimator.GetBool("visible"))
            {
                CloseBox();
            }
            else if(read && !panelAnimator.GetBool("visible"))
            {
                OpenBox();
            }
            else if(started)
            {
                DisplayNextSentence();
            }
        }

        if (character == null){
            character = person.text;
        }
    }

    public void SetDialogue(DialogueSpecial dialogue)
    {
        ending = false;
        read = false;
        started = false;
        talk.Enqueue(dialogue);
    }

    public void StartDialogue()
    {
        if(!started)
        {
            animator.SetBool("IsOpen", true);
            DisplayNextSentence();
            started = true;
        }
    }

    public void DisplayNextSentence()
    {
        if (talk.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueSpecial temp = talk.Dequeue();
        person.text = temp.name;
        character = person.text;
        string s = temp.sentence;
        StopAllCoroutines();
        SoundManagerScript.StopSound();
        StartCoroutine(TypeSentence(s, character));
    }

    public void CloseBox()
    {
        panelAnimator.SetBool("visible", false);
    }

    public void OpenBox()
    {
        panelAnimator.SetBool("visible", true);
    }

    IEnumerator TypeSentence (string sentence, string info)
    {
        words.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            
            words.text += letter;
            if (!ending){
                SoundManagerScript.PlaySound(info);
            }
            if (letter == ',' || letter == '.' || letter == '?' || letter == '!' || letter == '.'){
                yield return new WaitForSeconds(0.4f);
            } else {
                yield return new WaitForSeconds(0.03f);
            }
            //yield return null;
        }
    }
    void EndDialogue()
    {
        ending = true;
        read = true;
        animator.SetBool("IsOpen", false);
        exitend.SetActive(true);
        panelAnimator.SetBool("visible", true);
        move.Invoke();
        //unlockAbility.Invoke();
        //SoundManagerScript.StopSound();
        // if (!isEmotional){
        //     SoundManagerScript.PlaySound("power");
        // }      
    }
}
