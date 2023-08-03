using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiObject : MonoBehaviour
{
    protected StateMachine stateMachine;
    [HideInInspector] public string type;
    [SerializeField] GameObject[] waypoints;
    [SerializeField] public float speed = 1.0f;
    protected AiSight aiSight;
    protected GameObject player;
    protected HealthBar healthBar;
    [HideInInspector] public BarbarianAnimation barbarianAnimation;

    protected Attack_Point attackPoint;
    [SerializeField] public LayerMask playerLayers;
    public float attackCoolDown = 0.0f;
    private Vector2 destination;
    private float distanceToDestination = 2.0f;
    private bool hasAttacked = false;
    [SerializeField] protected float knockBackForce;
    protected float xp;
    protected string attackAnim;
    public string AttackAnim
    {
        get { return attackAnim; } 
    }
    public float XP
    {
        get { return xp; }
    }

    protected void SetXP(string type)
    {
        switch (type)
        {
            case "BarbAxeman":
                xp = 150;
                break;
            case "BarbBowmen":
                xp = 100;
                break;
            case "BarbBoss":
                xp = 250;
                break;
        }
    }

    protected virtual void Start()
    {
        FindPlayer();
        GameManager.Instance.AddRaider();
    }

    protected virtual void Awake()
    {
        InitialiseComponenets();
    }

    private void InitialiseComponenets()
    {
        aiSight = GetComponent<AiSight>();
        healthBar = GetComponentInChildren<HealthBar>();
        barbarianAnimation = GetComponent<BarbarianAnimation>();
        attackPoint = GetComponentInChildren<Attack_Point>();
    }

    private void FindPlayer()
    {
        player = PlayerManager.Instance.gameObject;
    }

    public void MoveAI()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody.velocity;
        Vector2 direction = ((Vector2)attackPoint.transform.position - destination);
        float distance = GetDistanceToDestintion();
        if (distance <= 0.5)
        {
            velocity.x = direction.normalized.x * -speed * (distance + 0.5f);
        }
        else
        {
            velocity.x = direction.normalized.x * -speed;

        }
        rigidbody.velocity = velocity;
    }

    public bool HasJustAttacked()
    {
        return hasAttacked;
    }


    public bool HasAttacked
    {
        set { hasAttacked = value; }
    }

    public bool IsInRangeOfTarget()
    {
        bool isInRange = distanceToDestination <= 0.1f;
        isInRange &= attackCoolDown <= 0.0f;
        return isInRange; 
    }

    public int GetNumWaypoints()
    {
        return waypoints.Length;
    }

    public Vector2 GetWaypoint(int waypointIndex)
    {
        return waypoints[waypointIndex].transform.position;
    }

    public void SetDestination(Vector2 Destination)
    {
        destination = Destination;
    }

    public Vector2 GetDestination()
    {
        return destination;
    }

    public void SetDistanceToDestintion()
    {
        Vector2 temp = (destination - (Vector2)attackPoint.transform.position);
        temp.y = 0;
        distanceToDestination = temp.magnitude;
    }

    public float GetDistanceToDestintion()
    {
        return distanceToDestination;
    }

    public Vector2 PlayerPosition
    {
        get
        {
            return player.transform.position;
        }
    }

}


