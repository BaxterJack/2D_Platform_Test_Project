using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    bool isMoving = false;
    float horizontalMove = 0.0f;

    bool hasDied = false;

    Vector2 barbPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barbPosition = transform.position;
        if (!hasDied)
        {
            WalkAnimation();
            FlipSprite();
        }
        
    }

    void WalkAnimation()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        horizontalMove = rigidbody2D.velocity.x;

        isMoving = horizontalMove > 0.1f || horizontalMove < -0.1f;
        animator.SetBool("IsBarbMoving", isMoving);

    }

    void FlipSprite()
    {
        if (IsGoingRight())
        {
            transform.localScale = new Vector3(-1, 1, 1);
            GetComponentInChildren<HealthBar>().transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (!IsGoingRight())
        {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponentInChildren<HealthBar>().transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public bool IsGoingRight()
    {
        Vector2 target = GetComponent<AiObject>().target;

        if (target.x > barbPosition.x) // Going right
        {
            return true;
        }
        else   //going Left
        {
            return false;
        }
    }

    public void Slash()
    {
        animator.SetTrigger("SlashAttack");
    }

    public void Die()
    {
        hasDied = true;
        animator.SetBool("HasDied", hasDied);
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Collider2D>().enabled = false;

        //this.enabled = false;
    }

    public bool IsAiDead()
    {
        return hasDied;
    }
}
