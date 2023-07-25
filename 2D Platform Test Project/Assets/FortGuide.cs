using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FortGuide : Singleton<FortGuide>
{

    string meetCommander = "Go and speak with the Fort Commander at the Gatehouse.";
    string meetCommanderTip = "Use the A & D key to move.";


    List<Goal>goals = new List<Goal>();

    public enum FortObjective
    {
        IntroduceCommander,
        Tutorial,
        SpeakWithCommander,
        SpeakWithBathHouse,

    }

    public void SetObjectivecomplete(FortObjective objective)
    {
        int index = (int)objective;
        goals[index].Complete = true;
    }

    FortObjective currentObjective;
    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        currentObjective = FortObjective.IntroduceCommander;
        AddGoal(meetCommander, meetCommanderTip);
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
                currentObjective = (FortObjective)i;
                break;
            }
        }
    }

    void Update()
    {
        FindCurrentObjective();
        int index = (int)currentObjective;
        InitialiseCurrentObjective(index);
    }

    string objPrefix = "Objective: ";
    void InitialiseCurrentObjective(int index)
    {
        switch (currentObjective)
        {
            case FortObjective.IntroduceCommander:
                UIManager.Instance.Objective.text = objPrefix + goals[index].Objective;
                UIManager.Instance.Tip.text = goals[index].Tip;

                break;
        }
    }
}
