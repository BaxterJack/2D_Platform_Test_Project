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

    bool isAttacking;

    float stabDamage = 35; //original
    //public float stabDamage = 100;
    int slashDamage = 50;

    public float StabDamage
    {
        get { return stabDamage; }
        set { stabDamage = value; }
    }


    PlayerManager playerManager;
    GameSceneManager gameSceneManager;
    private void Start()
    {
        playerManager = PlayerManager.Instance;
        gameSceneManager = GameSceneManager.Instance;
    }

    void Update()
    {

        if (playerManager.CurrentState == PlayerManager.PlayerState.Alive)
        {
            SetMoveAnimation();
            OrientPlayer();

            if (playerManager.CanAttack)
            {
                SetIsAttacking();
                if (Input.GetMouseButtonDown(0) && !isAttacking)
                {
                    StabAnimation();
                }
                if (Input.GetMouseButtonDown(1) && !isAttacking)
                {
                    SlashAnimation();
                }
            }
        }
        bool isDead = playerManager.CurrentState == PlayerManager.PlayerState.Dead;
        DieAnimation(isDead);



    }

    void DieAnimation(bool isDead)
    {
        animator.SetBool("HasDied", isDead);
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
            if(enemy.isTrigger == false)
            {
                enemy.GetComponentInChildren<HealthBar>().TakeDamage(stabDamage);
                AudioManager audioManager = AudioManager.Instance;
                audioManager.PlaySound("Hit");
            }

        }
    }

    void SlashAnimation()
    {
        animator.SetTrigger("Slash");
        
    }
    void SlashSound()
    {
        AudioManager audioManager = AudioManager.Instance;
        audioManager.PlaySound("Slash");
    }

    void ApplySlashDamage()
    {

        int tree = LayerMask.NameToLayer("ChoppableTree");
        int Enemy = LayerMask.NameToLayer("Enemy");
        AudioManager audioManager = AudioManager.Instance;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackPoint.attackRange/*, enemeyLayers*/);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.layer == Enemy &&  enemy.isTrigger == false)
            {
                enemy.GetComponentInChildren<HealthBar>().TakeDamage(slashDamage);
                
                audioManager.PlaySound("Hit");
            }
            if(enemy.gameObject.layer == tree)
            {
                enemy.GetComponent<TreeChopping>().TakeDamage();
                audioManager.PlaySound("Hit");
            }

        }
    }



}
