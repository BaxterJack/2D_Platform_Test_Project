using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    protected StateMachine stateMachine;
    bool hasConversationCompleted = false;

    [SerializeField]
    public GameObject waypoint;

    public float speed = 1.0f;

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

    public void MoveNPC()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody.velocity;
        Vector2 npcPosition = rigidbody.transform.transform.position;
        Vector2 direction = npcPosition - (Vector2)waypoint.transform.position;

        velocity.x = direction.normalized.x * -speed;
        rigidbody.velocity = velocity;  
    }
   
}
