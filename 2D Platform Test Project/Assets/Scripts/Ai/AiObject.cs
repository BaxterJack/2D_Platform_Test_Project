using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiObject : MonoBehaviour
{
    protected StateMachine stateMachine;
    public string type;
    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    public float speed = 1.0f;

    protected AiSight aiSight;

    protected GameObject player;

    protected HealthBar healthBar;

    public BarbarianAnimation barbarianAnimation;

    protected Attack_Point attackPoint;

    [SerializeField]
    public LayerMask playerLayers;

    public float attackOffset;

    public float attackCoolDown = 0.0f;

    public Vector2 destination;

    public float distanceToDestination = 2.0f;

    private bool hasAttacked = false;

    [SerializeField]
    protected float knockBackForce;

    protected float xp;

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

/////////////////////////////////////////////
///

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AiObject : MonoBehaviour
//{
//    protected StateMachine stateMachine;

//    [SerializeField]
//    GameObject[] waypoints;

//    [SerializeField]
//    public float speed = 1.0f;

//    [SerializeField]
//    public AiSight aiSight;


//    protected GameObject player;

//    [SerializeField]
//    public HealthBar healthBar;

//    [SerializeField]
//    public BarbarianAnimation barbarianAnimation;

//    [SerializeField]
//    public Attack_Point attackPoint;

//    [SerializeField]
//    public LayerMask playerLayers;

//    public float attackOffset;

//    public float attackCoolDown = 0.0f;

//    public Vector2 target;
//    public Vector2 destination;

//    public float distanceToDestination = 2.0f;

//    public bool hasAttacked = false;

//    private void Start()
//    {

//    }

//    protected void FindPlayer()
//    {
//        player = PlayerManager.Instance.gameObject;
//    }
//    public void MoveAI()
//    {
//        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
//        Vector2 velocity = rigidbody.velocity;
//        Vector2 barbPosition = rigidbody.transform.position;
//        Vector2 direction = (barbPosition - destination);
//        float distance = GetDistanceToDestintion();
//        if (distance <= 0.5)
//        {
//            velocity.x = direction.normalized.x * -speed * (distance + 0.5f);
//        }
//        else
//        {
//            velocity.x = direction.normalized.x * -speed;

//        }
//        //velocity.x = direction.normalized.x * -speed; // test
//        rigidbody.velocity = velocity;
//    }
//    public float AttackOffset
//    {
//        get
//        {
//            return attackOffset;
//        }
//        set
//        {
//            attackOffset = (transform.position.x - GetComponentInChildren<Attack_Point>().transform.position.x) * 1.25f;
//        }
//    }
//    public void SetAttackOffset()
//    {
//        attackOffset = (transform.position.x - GetComponentInChildren<Attack_Point>().transform.position.x) /** 1.25f*/;
//    }

//    public float GetAttackOffset()
//    {
//        return attackOffset;
//    }

//    public bool HasJustAttacked()
//    {
//        return hasAttacked;
//    }

//    public bool IsInRangeOfTarget()
//    {
//        bool isInRange = distanceToDestination <= 0.1f;
//        isInRange &= attackCoolDown <= 0.0f;
//        return isInRange;
//    }

//    public int GetNumWaypoints()
//    {
//        return waypoints.Length;
//    }

//    public Vector2 GetWaypoint(int waypointIndex)
//    {
//        return waypoints[waypointIndex].transform.position;
//    }

//    public void SetDestination(Vector2 Destination)
//    {
//        destination = Destination;
//    }

//    public void SetDestination(Vector2 Destination, float offset)
//    {
//        destination = Destination;
//        destination.x += offset;
//    }

//    public Vector2 GetDestination()
//    {
//        return destination;
//    }

//    public void SetTarget(Vector2 Target)
//    {
//        target = Target;
//    }

//    public void SetDistanceToDestintion()
//    {
//        //distanceToDestination = (destination - (Vector2)transform.position).magnitude;
//        Vector2 temp = (destination - (Vector2)transform.position);
//        temp.y = 0;
//        distanceToDestination = temp.magnitude;

//    }

//    public float GetDistanceToDestintion()
//    {
//        return distanceToDestination;
//    }

//    public Vector2 GetPlayerPosition()
//    {
//        return player.transform.position;
//    }

//    public Vector2 PlayerPosition
//    {
//        get
//        {
//            return player.transform.position;
//        }
//    }
//}

