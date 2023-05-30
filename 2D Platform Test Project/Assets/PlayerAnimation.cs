using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Attack_Point attackPoint;

    [SerializeField]
    LayerMask enemeyLayers;

    [SerializeField]
    HealthBar healthBar;

    bool isMoving = false;
    float horizontalMove = 0.0f;
    bool hasDied = false;

    Vector3 canvasScale;

    private void Start()
    {
        canvasScale = GetComponentInChildren<Canvas>().transform.localScale;
    }

    void Update()
    {
        if (hasDied == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            isMoving = horizontalMove != 0;

            animator.SetBool("IsMoving", isMoving);

            if (horizontalMove > 0.0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                GetComponentInChildren<HealthBar>().transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontalMove < 0.0f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                GetComponentInChildren<HealthBar>().transform.localScale = new Vector3(1, 1, 1);
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
            if (healthBar.HasNoHealth())
            {
                Die();
            }
        }
       
    }

    void Stab()
    {
        animator.SetTrigger("Stab");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackPoint.attackRange, enemeyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponentInChildren<HealthBar>().TakeDamage(20);
            Debug.Log("We hit " + enemy.name);
        }
    }

    void Slash()
    {
        animator.SetTrigger("Slash");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackPoint.attackRange, enemeyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponentInChildren<HealthBar>().TakeDamage(35);
        }
    }

    void Die()
    {
        hasDied = true;
        animator.SetBool("HasDied", hasDied);
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Collider2D>().enabled = false;
       /* GameObject gameObject = */GetComponent<GameObject>().layer = 0;
       // gameObject.layer = 0;
    }

}
