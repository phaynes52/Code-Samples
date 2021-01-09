using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSpecial
{
    public string name;
    [TextArea(4, 10)]
    public string sentence;
    
     public string getName(){
        return name;
    }
}
