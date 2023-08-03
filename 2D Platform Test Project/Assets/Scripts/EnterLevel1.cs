using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FortGuide;

public class EnterLevel1 : MonoBehaviour
{
    List<Goal> goals = new List<Goal>();
    string raiders = "Clear out all of the raiders on your way to Newbrough Fort.";
    string brocchus = "Go and speak with the Newbrough Fort Commander, Aelius Brocchus.";
    public enum Level1Objectives
    {
        ClearRaiders,
        SpeakWithBrocchus
    }
    Level1Objectives currentObjective;

    void Start()
    {
        //if(FortGuide.Instance != null)
        //{
        //    FortGuide.Instance.gameObject.SetActive(false);
        //}
        
        PlayerManager.Instance.CanAttack = true;
        GameManager.Instance.ActivateNPCS(false, NPC.npcTypes.fort);
        PlayerManager.Instance.gameObject.transform.position = gameObject.transform.position;
        currentObjective = Level1Objectives.ClearRaiders;
        AddGoal(raiders, "");
        AddGoal(brocchus, "");
        InitialiseCurrentObjective((int)currentObjective);
    }
    bool isSecondObjectiveAssigned = false;

    private void Update()
    {
        if ( !isSecondObjectiveAssigned && GameManager.Instance.AreRaidersCleared())
        {
            SetObjectivecomplete(Level1Objectives.ClearRaiders);
            isSecondObjectiveAssigned= true;
        }
    }


    void AddGoal(string Objective, string Tip)
    {
        goals.Add(new Goal(Objective, Tip));
    }

    void FindCurrentObjective()
    {
        int size = goals.Count;
        for (int i = 0; i < size; i++)
        {
            if (goals[i].Complete == false)
            {
                currentObjective = (Level1Objectives)i;
                break;
            }


        }

    }

    string objPrefix = "Objective: ";
    void InitialiseCurrentObjective(int index)
    {
        UIManager.Instance.Objective.text = objPrefix + goals[index].Objective;
        UIManager.Instance.Tip.text = goals[index].Tip;
    }

    public void SetObjectivecomplete(Level1Objectives objective)
    {

        int index = (int)objective;
        goals[index].Complete = true;
        FindCurrentObjective();
        index = (int)currentObjective;
        InitialiseCurrentObjective(index);

    }
}
