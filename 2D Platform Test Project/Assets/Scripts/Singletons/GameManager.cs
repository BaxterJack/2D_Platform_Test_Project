using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NPC;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    bool isTutorialComplete = false;
    List<NPC> nPCs = new List<NPC>();
    bool isGodsQuizComplete = false;
    GodsQuiz godsQuiz;
    bool isBathHouseConstucted = false;
    [SerializeField]
    int raidersCount = 0;
    public int raidersCleared = 0;

    public GameObject lepidinaPrefab;
    public void ResetRaiderCount()
    {
        raidersCount = 0;
    }
    public int RaidersCleared
    {
        get { return raidersCleared; }
        set { raidersCleared = value; }
    }
    public void AddNPC(NPC npc)
    {
        nPCs.Add(npc);
    }
    public bool BathHouseConstructed
    {
        set {  isBathHouseConstucted = value;}
    }
    public bool IsBathHouseConstructed()
    {
        return isBathHouseConstucted;
    }

    public bool AreRaidersCleared()
    {
        return raidersCleared == raidersCount;
    }

    public void AddRaider()
    {
        raidersCount++;
    }
    public void ActivateNPCS(bool isActive)
    {
        foreach (NPC npc in nPCs)
        {
            npc.ActivateNPC(isActive);
        }
    }

    public void ActivateNPCS(bool isActive, npcTypes Type)
    {
        foreach (NPC npc in nPCs)
        {
            npc.ActivateNpcType(isActive, Type);
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

    public void ActivateGodsQuiz()
    {
        godsQuiz = FindObjectOfType<GodsQuiz>();
        godsQuiz.ShowCanvas(true);
    }

    public void SetGodsQuizComplete()
    {
        isGodsQuizComplete = true;
        godsQuiz.ShowCanvas(false);
    }

    public bool IsGodsQuizComplete()
    {
        return isGodsQuizComplete;
    }

    public void InstatiateLepidina()
    {
        GameObject instantiatedPrefab = Instantiate(lepidinaPrefab);
        instantiatedPrefab.transform.position = new Vector3(24.43f, -3.69f, 0f);
        instantiatedPrefab.transform.rotation = Quaternion.identity;
    }
}