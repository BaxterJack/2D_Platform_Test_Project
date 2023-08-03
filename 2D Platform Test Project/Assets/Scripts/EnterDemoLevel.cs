using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDemoLevel : MonoBehaviour
{
    
    void Start()
    {
        PlayerManager playerManager = PlayerManager.Instance;
        playerManager.gameObject.transform.position = transform.position;
        GameManager.Instance.ActivateNPCS(false);
    }

}
