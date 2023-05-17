using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSight : MonoBehaviour
{
    [SerializeField]
    float sightRange = 5f;

    public bool canSeePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        canSeePlayer = CanSeePlayer();
    }

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

        Debug.DrawRay(AiPosition, forwardDirection * sightRange, Color.red);

        if (rayHit)
        {
            Debug.Log("I can see the player");
            return true;
        }
 
        return false;
    }
}
