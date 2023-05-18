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

    bool isMoving = false;
    float horizontalMove = 0.0f;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        isMoving = horizontalMove != 0;

        animator.SetBool("IsMoving", isMoving);

        if (horizontalMove > 0.0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalMove < 0.0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
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

    void Stab()
    {
        animator.SetTrigger("Stab");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackPoint.attackRange, enemeyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponentInChildren<Barbarian>().TakeDamage(20);
        }
    }

    void Slash()
    {
        animator.SetTrigger("Slash");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackPoint.attackRange, enemeyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponentInChildren<Barbarian>().TakeDamage(35);
        }
    }

}
