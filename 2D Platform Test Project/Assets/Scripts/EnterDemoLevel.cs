using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDemoLevel : MonoBehaviour
{
    
    void Start()
    {
        PlayerManager playerManager = PlayerManager.Instance;
        playerManager.player.transform.position = transform.position;
        GameManager.Instance.ActivateNPCS(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
