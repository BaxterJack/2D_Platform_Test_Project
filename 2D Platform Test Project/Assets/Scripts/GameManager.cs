using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
//   [SerializeField]
    GameObject player;

//   [SerializeField]
    HealthBar playerHealth;

//   [SerializeField]
    UIManager uiManager;

    float respawnTimer = 0.0f;

    PlayerState currentState = PlayerState.Alive;

    int playerLayer;

    public enum PlayerState
    {
        Alive,
        Dead
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
                playerHealth.gameObject.SetActive(true);

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
        
        if(currentState == PlayerState.Dead)
        {
            respawnTimer += Time.deltaTime;
            Debug.Log(respawnTimer);
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
        for(int i =0; i < player.transform.childCount; i++)
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

}