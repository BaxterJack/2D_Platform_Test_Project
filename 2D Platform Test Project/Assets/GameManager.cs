using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    GameObject player;

    [SerializeField]
    HealthBar playerHealth;

    [SerializeField]
    UIManager uiManager;

    float respawnTimer = 0.0f;
    bool hasDied = false;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Game Manager is Null");
            }
            return instance;
        }
    }

    private void Update()
    {
        if (hasDied)
        {
            StartRespawnTimer();
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {

    }

    public void RespawnPlayer()
    {
        uiManager.DecreaseLives();
        playerHealth.gameObject.SetActive(true);
        playerHealth.SetCurrentHealth(playerHealth.maxHealth);
        player.gameObject.GetComponent<Rigidbody2D>().gravityScale = 6.0f;
        player.gameObject.GetComponent<Collider2D>().enabled = true;
        Vector3 deathPos = player.transform.position;
        Vector3 respawnPos = deathPos;
        respawnPos.y += 2;
        player.transform.position = respawnPos; 
    }
    public void PlayerHasDied()
    {
        hasDied = true;
    }
    public void StartRespawnTimer()
    {
       respawnTimer += Time.deltaTime;
        if (respawnTimer > 3.0f)
        {
            respawnTimer = 0.0f;
            hasDied=false;
            player.GetComponent<PlayerAnimation>().animator.SetBool("HasDied", false);
            RespawnPlayer();
        }
    }
}
