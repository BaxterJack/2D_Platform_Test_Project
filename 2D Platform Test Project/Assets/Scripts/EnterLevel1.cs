using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.CanAttack = true;
        GameManager.Instance.ActivateNPCS(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
