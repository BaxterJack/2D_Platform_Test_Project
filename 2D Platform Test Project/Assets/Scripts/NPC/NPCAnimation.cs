using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    bool isMoving = false;
    float horizontalMove = 0.0f;

    Vector2 npcPosition;

    GameSceneManager gameSceneManager;
    Rigidbody2D rB;

    private void Start()
    {
        gameSceneManager = GameSceneManager.Instance;
        rB = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
 
        npcPosition = gameObject.transform.position;
        float xSpeed = rB.velocity.x;
        WalkAnimation(xSpeed);
        if(xSpeed != 0.0f )
        {
            FlipSprite(xSpeed);
        }
        

           
    }
    void WalkAnimation(float xSpeed)
    {
        //Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        //horizontalMove = rigidbody2D.velocity.x;

       // isMoving = horizontalMove > 0.1f || horizontalMove < -0.1f;
        isMoving = xSpeed > 0.1f || xSpeed < -0.1f;
        animator.SetBool("IsMoving", isMoving);

    }

    void FlipSprite(float xSpeed)
    {
        if (IsGoingRight(xSpeed))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        else if (!IsGoingRight(xSpeed))
        {
            transform.localScale = new Vector3(1, 1, 1);
            
        }
    }

    public bool IsGoingRight(float xSpeed)
    {

        //float xSpeed = rB.velocity.x;

        if (xSpeed > 0)
        {
            return true;
        }
        else   //going Left
        {
            return false;
        }

    }


}
