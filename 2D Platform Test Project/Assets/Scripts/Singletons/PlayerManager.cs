using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject player;

    HealthBar playerHealth;

    UIManager uiManager;

    float respawnTimer = 0.0f;

    PlayerState currentState = PlayerState.Alive;

    int playerLayer;

    Vector3 lastFortPosition = new Vector3();

    bool canAttack = false;

    bool canAttackCheck = false;

    Vector3 checkpoint = new Vector3();
    public enum PlayerState
    {
        Alive,
        Dead
    }

    public Vector3 Checkpoint
    {
        get { return checkpoint; }
        set { checkpoint = value; }
    }

    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; /*Debug.Log("changed can attack");*/ }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public PlayerState CurrentState
    {
        get { return currentState; }
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
                DestroyArrows();
                uiManager.DecreaseLives();
                player.layer = 15;
                player.tag = "Enemy";
                break;
        }
    }

    void CanAttackCheck()
    {
        if(canAttackCheck != canAttack)
        {
            if(canAttack == true)
            {
                canAttackCheck = true;
                Debug.Log("Weapons Enabled");
            }
            else if(canAttack == false)
            {
                canAttackCheck = false;
                Debug.Log("Weapons Disabled");
            }
        }
    }

    private void Update()
    {
        //CanAttackCheck();
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

    private void Start()
    {

        player = GameObject.Find("Player");
        playerLayer = player.layer;
        playerHealth = player.GetComponentInChildren<HealthBar>();
        GameObject obj = GameObject.Find("UICanvas");
        uiManager = obj.GetComponent<UIManager>();
    }

    public void GameOver()
    {

    }

    public void RespawnPlayer()
    {
        //Vector3 deathPos = player.transform.position;
        //Vector3 respawnPos = deathPos;
        //respawnPos.y += 2;
        player.transform.position = checkpoint;
    }

    public void SaveFortPosition()
    {
        lastFortPosition = player.transform.position;
    }

    public void SetFortPosition()
    {
        player.transform.position = lastFortPosition;

    }

    public void IncreaseStabDamage()
    {
        PlayerAnimation anim = GetComponent<PlayerAnimation>();
        anim.StabDamage *= 1.1f;
    }
}
