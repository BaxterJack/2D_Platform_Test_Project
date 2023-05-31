using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField]
    public Animator animator;

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
    bool isAttacking;

    int stabDamage = 20;
    int slashDamage = 35;
    private void Start()
    {

    }

    void Update()
    {
        if (hasDied == false)
        {
            SetMoveAnimation();
            OrientPlayer();
            SetIsAttacking();

            if (Input.GetMouseButtonDown(0) && !isAttacking)
            {
                StabAnimation();
            }
            if (Input.GetMouseButtonDown(1) && !isAttacking)
            {
                SlashAnimation();
            }
            if (healthBar.HasNoHealth())
            {
                Die();
            }
        }
       
    }

    void SetMoveAnimation()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        isMoving = horizontalMove != 0;
        animator.SetBool("IsMoving", isMoving);
    }

    void SetIsAttacking()
    {
        isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName("Stab");
        isAttacking |= animator.GetCurrentAnimatorStateInfo(0).IsName("Slash");
    }

    void OrientPlayer()
    {
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
    }

    void StabAnimation()
    {
        animator.SetTrigger("Stab");
    }

    void ApplyStabDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackPoint.attackRange, enemeyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponentInChildren<HealthBar>().TakeDamage(stabDamage);
        }
    }

    void SlashAnimation()
    {
        animator.SetTrigger("Slash");
    }

    void ApplySlashDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackPoint.attackRange, enemeyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponentInChildren<HealthBar>().TakeDamage(slashDamage);
        }
    }

    void Die()
    {
        hasDied = true;
        DieAnimation(hasDied);
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        //GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<GameObject>().layer = 0;
        
    }

    void DieAnimation(bool hasDied)
    {
        animator.SetBool("HasDied", hasDied);
    }
    void Died()
    {
        GameManager manager = GameManager.Instance;
        hasDied = false;
        manager.PlayerHasDied();
    }

}
