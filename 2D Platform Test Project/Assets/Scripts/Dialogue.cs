using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name;

    [TextArea(3, 10)]
    public List<string> sentences;

    public bool HasTabletPuzzle;
    private bool hasConversationCompleted;
    private bool isForcedDialogue;

    public Dialogue()
    {
        sentences = new List<string>();
        name = string.Empty;
        HasTabletPuzzle = new bool();
        hasConversationCompleted = false;
        isForcedDialogue = false;
    }

    public bool ConversationComplete
    {
        get { return hasConversationCompleted; }
        
        set { hasConversationCompleted = value;}
    }

    public bool ForcedDialogue
    {
        get { return isForcedDialogue; }
        set { isForcedDialogue = value;}
    }
}
