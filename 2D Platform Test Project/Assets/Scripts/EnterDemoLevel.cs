using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDemoLevel : MonoBehaviour
{
    
    void Start()
    {
        PlayerManager playerManager = PlayerManager.Instance;
        Debug.Log(playerManager.player.transform.position);
        playerManager.player.transform.position = transform.position;
        Debug.Log(playerManager.player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
