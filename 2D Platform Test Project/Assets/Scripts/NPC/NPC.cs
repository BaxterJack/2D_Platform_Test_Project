using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    protected StateMachine stateMachine;

    public Vector3 homeWaypoint;

    public Vector3 destinationWaypoint;

    public float speed = 1.0f;

    private float distanceToDestination;
    public float DistanceToDestination
    {
        get { return distanceToDestination; }
        set { distanceToDestination = value; }
    }
    private float distanceToHome;
    public float DistanceToHome
    {
        get { return distanceToHome; }
        set { distanceToHome = value; }
    }

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
        distanceToHome = 10;
    }


    public float SetDistance(Vector3 waypoint)
    {
        Vector2 distance = (waypoint - gameObject.transform.position);
        distance.y = 0;
        return distance.magnitude;
    }

    public bool HasReachedDestination()
    {
        return distanceToDestination <= 0.1;
    }

    public bool HasReachedHome()
    {
        return distanceToHome <= 0.1;
    }

    public void SetDestination()
    {
        Vector3 playerPos = PlayerManager.Instance.transform.position;

        Vector3 npcPos = transform.position;
        Vector3 directionToPlayer = playerPos - npcPos;

        float offset = (directionToPlayer.x < 0) ? 0.5f : -0.5f;
        playerPos.x += offset;
        destinationWaypoint = playerPos;
    }


    public void MoveNPC(Vector3 waypoint)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody.velocity;
        Vector2 npcPosition = rigidbody.transform.transform.position;
        Vector2 direction = npcPosition - (Vector2)waypoint;
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

    public void SetHasConversationCompleted(bool hasConversationCompleted)
    {
        dialogueTrigger.dialogue.ConversationComplete = hasConversationCompleted;
    }

    public bool GetHasConversationCompleted()
    {
        return dialogueTrigger.dialogue.ConversationComplete;
    }
    public void AssignDialogue(Dialogue dialogue)
    {
        dialogueTrigger.dialogue = dialogue;
    }


}
