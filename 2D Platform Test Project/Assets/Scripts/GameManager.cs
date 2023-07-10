using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    bool isTutorialComplete = false;
    List<NPC> nPCs = new List<NPC>();


    public void AddNPC(NPC npc)
    {
        nPCs.Add(npc);
    }

    public void ActivateNPCS(bool isActive)
    {
        foreach (NPC npc in nPCs)
        {
            npc.ActivateNPC(isActive);
        }
    }

    public bool TutorialComplete
    {
        set { isTutorialComplete = value; }
    }
    public bool IsTutorialComplete()
    {
        return isTutorialComplete;
    }

}