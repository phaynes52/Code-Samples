using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
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

    public UnityEvent unlockAbility;

    // Start is called before the first frame update
    void Start()
    {
        exitend.SetActive(false);
        sentences = new Queue<string>();
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
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if(!started)
        {
            animator.SetBool("IsOpen", true);
            person.text = dialogue.name;
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
            started = true;
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        SoundManagerScript.StopSound();
        StartCoroutine(TypeSentence(sentence, character));
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
        unlockAbility.Invoke();
        SoundManagerScript.StopSound();
        if (!isEmotional){
            SoundManagerScript.PlaySound("power");
        }      
    }
}
