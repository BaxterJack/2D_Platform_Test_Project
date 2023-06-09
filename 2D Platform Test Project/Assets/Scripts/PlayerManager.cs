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

    public enum PlayerState
    {
        Alive,
        Dead
    }

    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
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
                player.GetComponent<Rigidbody2D>().gravityScale = 6.0f;
                player.GetComponent<Collider2D>().enabled = true;
                player.layer = playerLayer;
                playerHealth.SetMaxHealth();
                playerHealth.EnableHealthCanvas();

                break;

            case PlayerState.Dead:
                DestroyArrows();
                uiManager.DecreaseLives();
                player.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                player.GetComponent<Collider2D>().enabled = false;
                player.layer = 0;
                break;
        }
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
        Vector3 deathPos = player.transform.position;
        Vector3 respawnPos = deathPos;
        respawnPos.y += 2;
        player.transform.position = respawnPos;
    }

    public void SaveFortPosition()
    {
        lastFortPosition = player.transform.position;
    }

    public void SetFortPosition()
    {
        player.transform.position = lastFortPosition;
    }
}
