using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    protected StateMachine stateMachine;
    bool hasConversationCompleted = false;

    [SerializeField]
    GameObject waypoint;
    //public bool HasConversationCompleted
    //{
    //    get { return hasConversationCompleted; }
    //    set { hasConversationCompleted = value; }
    //}

    public void SetHasConversationCompleted(bool hasConversationCompleted)
    {
        this.hasConversationCompleted = hasConversationCompleted;
    }

    public bool GetHasConversationCompleted()
    {
        return hasConversationCompleted;
    }
    public void AssignDialogue(Dialogue dialogue)
    {
        GetComponent<DialogueTrigger>().dialogue = dialogue;
    }
   
}
