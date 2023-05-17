using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    bool isMoving = false;
    float horizontalMove = 0.0f;

    bool hasDied = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasDied)
        {
            SpriteAnimation();
        }
        
    }

    void SpriteAnimation()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        horizontalMove = rigidbody2D.velocity.x;

        isMoving = horizontalMove > 1.73f || horizontalMove < -1.73f;
        animator.SetBool("IsBarbMoving", isMoving);

        Vector2 direction = GetComponent<Barbarian>().GetDirection();

        if (direction.x < 0.2f)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0.2f)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void Die()
    {
        hasDied = true;
        animator.SetBool("HasDied", hasDied);
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;
    }

    public bool IsAiDead()
    {
        return hasDied;
    }
}
