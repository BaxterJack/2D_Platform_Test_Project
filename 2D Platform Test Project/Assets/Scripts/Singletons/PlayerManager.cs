using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private int maxLives;
    public int MaxLives    { get { return maxLives; }    }
    public int currentLives { get; set; }
    GameObject player;
    HealthBar playerHealth;
    float respawnTimer = 0.0f;
    PlayerState currentState = PlayerState.Alive;
    int playerLayer;
    bool canAttack = false;
    bool canAttackCheck = false;
    Vector3 checkpoint = new Vector3();
    public enum PlayerState
    {
        Alive,
        Dead
    }
    public PlayerState CurrentState
    {
        get { return currentState; }
    }
    public int GetDamageTaken()
    {
        return playerHealth.DamageTaken;
    }

    public Vector3 Checkpoint
    {
        get { return checkpoint; }
        set { checkpoint = value; }
    }

    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        currentLives = maxLives;
        player = this.gameObject;
        playerLayer = player.layer;
        playerHealth = player.GetComponentInChildren<HealthBar>();
    }

    private void Start()
    {
        
    }


    private void Update()
    {
        if (currentState == PlayerState.Dead)
        {
            respawnTimer += Time.deltaTime;
        }
        else if (playerHealth.HasNoHealth())
        {
            ChangePlayerState(PlayerState.Dead);
        }
        if (respawnTimer > 5)
        {
            respawnTimer = 0;
            ChangePlayerState(PlayerState.Alive);
            RespawnPlayer();
        }
    }


    public void ChangePlayerState(PlayerState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case PlayerState.Alive:
                player.layer = playerLayer;
                player.tag = "Player";
                playerHealth.SetMaxHealth();
                playerHealth.EnableHealthCanvas();
                break;

            case PlayerState.Dead:
                player.layer = 15;
                player.tag = "Enemy";
                DestroyArrows();
                DecreaseLives();       
                break;
        }
    }

    public void DecreaseLives()
    {
        currentLives--;
        UIManager.Instance.RemoveHeart(currentLives);
        if (currentLives > 0)
        {
            AudioManager.Instance.PlaySound("Revived");
        }
        if (currentLives == 0)
        {
            AudioManager.Instance.StopTheme();
            AudioManager.Instance.PlayTheme("Death");
            StartCoroutine(StopGame());
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }

    IEnumerator StopGame()
    {
        yield return new WaitForSeconds(3);
        UIManager.Instance.ActivateGameOverUI();
        GameOver();
    }





    void DestroyArrows()
    {
        for (int i = 0; i < player.transform.childCount; i++)
        {
            GameObject arrow = player.transform.GetChild(i).gameObject;


            if (arrow.CompareTag("EnemyArrow"))
            {
                Destroy(arrow);
            }
        }

    }



    public void RespawnPlayer()
    {
        player.transform.position = checkpoint;
    }


    public void IncreaseStabDamage()
    {
        PlayerAnimation anim = GetComponent<PlayerAnimation>();
        anim.StabDamage *= 1.1f;
    }

    public void IncreaseSpeed()
    {
        Player.PlayerMovement movement = GetComponent<Player.PlayerMovement>();
        movement.BoostSpeed();

      
    }

    public void IncreaseVitality()
    {
        HealthBar health = GetComponentInChildren<HealthBar>();
        health.maxHealth = 130;
        health.SetMaxHealth();
    }



    void CanAttackCheck()
    {
        if (canAttackCheck != canAttack)
        {
            if (canAttack == true)
            {
                canAttackCheck = true;
                Debug.Log("Weapons Enabled");
            }
            else if (canAttack == false)
            {
                canAttackCheck = false;
                Debug.Log("Weapons Disabled");
            }
        }
    }
}
