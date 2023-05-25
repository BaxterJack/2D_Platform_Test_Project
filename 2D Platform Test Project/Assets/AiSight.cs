using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSight : MonoBehaviour
{
    [SerializeField]
    float sightRange = 5f;

    public bool CanSeePlayer()
    {
        Vector2 AiPosition = this.transform.position;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        float horizontalSpeed = rigidbody2D.velocity.x;
        Vector2 forwardDirection = this.transform.right.normalized;
        if (horizontalSpeed < 0.0f)
        {
            forwardDirection *= -1;
        }
        LayerMask playerMask = LayerMask.GetMask("Player");
        RaycastHit2D rayHit = Physics2D.Raycast(AiPosition, forwardDirection, sightRange, playerMask);
        if (rayHit)
        {
            return true;
        }
        rayHit = Physics2D.Raycast(AiPosition, -forwardDirection, sightRange/2, playerMask);
        if (rayHit)
        {
            return true;
        }

        return false;
    }

    public bool CannotSeePlayer()
    {
        Vector2 AiPosition = this.transform.position;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        float horizontalSpeed = rigidbody2D.velocity.x;
        Vector2 forwardDirection = this.transform.right.normalized;
        if (horizontalSpeed < 0.0f)
        {
            forwardDirection *= -1;
        }
        LayerMask playerMask = LayerMask.GetMask("Player");

        RaycastHit2D rayHit = Physics2D.Raycast(AiPosition, forwardDirection, sightRange, playerMask);
        if (rayHit)
        {
            return false;
        }
        rayHit = Physics2D.Raycast(AiPosition, -forwardDirection, sightRange / 2, playerMask);
        if (rayHit)
        {
            return false;
        }
        return true;
    }
}
