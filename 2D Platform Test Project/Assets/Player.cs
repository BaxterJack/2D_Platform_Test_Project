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
    Transform attackPoint;
    [SerializeField]
    float attackRange = 0.3f;
    [SerializeField]
    LayerMask enemeyLayers;

    float point;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    bool isMoving = false;
    float horizontalMove = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        point = attackPoint.localPosition.x;
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

            InvertAttackPosition(-1);

        }
        else if (horizontalMove < 0.0f)
        {
            spriteRenderer.flipX = false;
            InvertAttackPosition(1);

        }
        bool isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName("Stab");
        isAttacking |= animator.GetCurrentAnimatorStateInfo(0).IsName("Slash");

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Stab();
        }

        if (Input.GetMouseButtonDown(1) && !isAttacking)
        {
            Slash();
        }

    }

    void InvertAttackPosition(int inversion)
    {
        Vector2 localPoint = attackPoint.localPosition;
        localPoint.x = inversion * point;
        attackPoint.localPosition = localPoint;
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

        if(Input.GetKey(KeyCode.Space))
        {
            velocity.y = jumpSpeed;
        }

        rigidbody2D.velocity = velocity;
    }

    void Stab()
    {
        animator.SetTrigger("Stab");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemeyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponentInChildren<Barbarian>().TakeDamage(20);
        }
    }

    void Slash()
    {
        animator.SetTrigger("Slash");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemeyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponentInChildren<Barbarian>().TakeDamage(35);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
    