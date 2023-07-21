using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSight : MonoBehaviour
{
    //[SerializeField]
    //float sightRange = 5f;
    PlayerManager playerManager;

    bool canSeePlayer = false;
    public bool CanSeePlayer()
    {
        return canSeePlayer;
    }

    public bool CannotSeePlayer()
    {
        if(!canSeePlayer == true)
        {
            Debug.Log("I have lost the player");
        }

        return !canSeePlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Debug.Log("I can see player");
            canSeePlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("I have lost the player");
            canSeePlayer = false;
        }
    }

    private void Update()
    {
        if(playerManager.CurrentState == PlayerManager.PlayerState.Dead)
        {
            canSeePlayer = false;
        }  
    }

    private void Start()
    {
        playerManager = PlayerManager.Instance;
    }




    //public bool CanSeePlayer()
    //{
    //    Vector2 AiPosition = this.transform.position;
    //    Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
    //    float horizontalSpeed = rigidbody2D.velocity.x;
    //    Vector2 forwardDirection = this.transform.right.normalized;
    //    if (horizontalSpeed < 0.0f)
    //    {
    //        forwardDirection *= -1;
    //    }
    //    LayerMask playerMask = LayerMask.GetMask("Player");
    //    RaycastHit2D rayHit = Physics2D.Raycast(AiPosition, forwardDirection, sightRange, playerMask);
    //    Debug.DrawRay(AiPosition, forwardDirection * sightRange, Color.blue);
    //    if (rayHit)
    //    {
    //        return true;
    //    }
    //    rayHit = Physics2D.Raycast(AiPosition, -forwardDirection, sightRange / 2, playerMask);
    //    Debug.DrawRay(AiPosition, -forwardDirection * sightRange / 2, Color.red);
    //    if (rayHit)
    //    {
    //        return true;
    //    }

    //    return false;
    //}

    //public bool CannotSeePlayer()
    //{
    //    Vector2 AiPosition = this.transform.position;
    //    Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
    //    float horizontalSpeed = rigidbody2D.velocity.x;
    //    Vector2 forwardDirection = this.transform.right.normalized;
    //    if (horizontalSpeed < 0.0f)
    //    {
    //        forwardDirection *= -1;
    //    }
    //    LayerMask playerMask = LayerMask.GetMask("Player");

    //    RaycastHit2D rayHit = Physics2D.Raycast(AiPosition, forwardDirection, sightRange, playerMask);
    //    if (rayHit)
    //    {
    //        return false;
    //    }
    //    rayHit = Physics2D.Raycast(AiPosition, -forwardDirection, sightRange / 2, playerMask);
    //    if (rayHit)
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}
