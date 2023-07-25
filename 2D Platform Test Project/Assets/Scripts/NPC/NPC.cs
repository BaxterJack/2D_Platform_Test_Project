using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    protected StateMachine stateMachine;

    public Vector3 homeWaypoint;

    public float speed = 1.0f;

    private float distanceToDestination;

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
        distanceToDestination = 10;
    }
    public void SetHasConversationCompleted(bool hasConversationCompleted)
    {
        dialogueTrigger.dialogue.ConversationComplete = hasConversationCompleted;
    }

    protected void SetDistance()
    {
        Vector2 distance = (homeWaypoint - gameObject.transform.position);
        distance.y = 0;
        distanceToDestination = distance.magnitude;
    }

    public bool GetHasConversationCompleted()
    {
        return dialogueTrigger.dialogue.ConversationComplete;
    }
    public void AssignDialogue(Dialogue dialogue)
    {
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




    public void AssignTablet(Tablet t)
    {
        TabletManager.Instance.CurrentTablet = t;   
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

    public bool HasReachedDestination()
    {
        return distanceToDestination <= 0.1;
    }




}
