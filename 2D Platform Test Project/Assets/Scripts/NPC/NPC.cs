using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    protected StateMachine stateMachine;
//    public bool hasConversationCompleted = false;

    public Vector3 homeWaypoint;

    public float speed = 1.0f;

    DialogueTrigger dialogueTrigger;
    protected npcTypes type;
    public enum npcTypes
    {
        fort,
        level1
    }

    protected virtual void Start()
    {
        GameManager.Instance.AddNPC(this);
        dialogueTrigger = gameObject.GetComponent<DialogueTrigger>();
    }
    public void SetHasConversationCompleted(bool hasConversationCompleted)
    {
        //this.hasConversationCompleted = hasConversationCompleted;
        dialogueTrigger.dialogue.ConversationComplete = hasConversationCompleted;
    }

    public bool GetHasConversationCompleted()
    {
        //return hasConversationCompleted;
        return dialogueTrigger.dialogue.ConversationComplete;
    }
    public void AssignDialogue(Dialogue dialogue)
    {
        //GetComponent<DialogueTrigger>().dialogue = dialogue;
        dialogueTrigger.dialogue = dialogue;
    }

    public void MoveNPC()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody.velocity;
        Vector2 npcPosition = rigidbody.transform.transform.position;
        Vector2 direction = npcPosition - (Vector2)homeWaypoint;

        velocity.x = direction.normalized.x * -speed;
        rigidbody.velocity = velocity;  
    }

    public void ActivateNPC(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void ActivateNpcType(bool isActive, npcTypes Type)
    {
        if(type == Type)
        {
            gameObject.SetActive(isActive);
        }
        else
        {
            gameObject.SetActive(!isActive);
        }
        
    }


}
