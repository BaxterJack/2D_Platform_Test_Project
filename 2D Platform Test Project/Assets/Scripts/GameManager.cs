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
    bool isGodsQuizComplete = false;
    GodsQuiz godsQuiz;

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
}