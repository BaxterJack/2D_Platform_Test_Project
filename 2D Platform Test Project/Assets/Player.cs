using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float jumpSpeed = 40.0f;
    [SerializeField]
    Animator animator;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    bool isMoving = false;
    float horizontalMove = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        isMoving = horizontalMove != 0;


        animator.SetBool("IsMoving", isMoving);

        if(horizontalMove > 0.0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalMove < 0.0f)
        {
            spriteRenderer.flipX = false;
        }
        bool isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName("Stab");
        isAttacking |= animator.GetCurrentAnimatorStateInfo(0).IsName("Slash");

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            animator.SetTrigger("Stab");
        }

        if (Input.GetMouseButtonDown(1) && !isAttacking)
        {
            animator.SetTrigger("Slash");
        }

    }

    private void FixedUpdate()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        Vector3 velocity = rigidbody2D.velocity;

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }
        //if (Input.GetKey(KeyCode.W))
        //{
        //    velocity.z = speed;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    velocity.z = -speed;
        //}
        if(Input.GetKey(KeyCode.Space))
        {
            velocity.y = jumpSpeed;
        }

        rigidbody2D.velocity = velocity;
    }
}
