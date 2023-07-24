using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel1 : MonoBehaviour
{

    void Start()
    {
        PlayerManager.Instance.CanAttack = true;
        GameManager.Instance.ActivateNPCS(false, NPC.npcTypes.fort);

    }


}
