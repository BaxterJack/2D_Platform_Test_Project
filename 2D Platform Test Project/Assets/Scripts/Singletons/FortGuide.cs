using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FortGuide : Singleton<FortGuide>
{

    string introduceCommander = "Go and speak with the Fort Commander at the Gatehouse.";
    string introduceCommanderTip = "Use the A & D key to move.";
    string tutorial = "Go to the Master at Arms for basic training.";
    string tutorialTip = "You can find Gaius Armatus to the right of the blacksmith.";
    string speakWithCommander = "Speak with the Fort Commander.";
    string speakWithCommanderTip = "The commanders house is to the right of the training field.";
    string speakWithBathhouse = "Send the tablet message to Vitalis, the BathHouse keeper.";
    string speakWithBathhouseTip = "The bathouse is the unconstructed building to the east of the commanders house.";
    string getLumber = "Chop down one tree to get lumber for construction.";
    string getLumberTip = "There are trees outside the eastern gate.";
    string findArtefacts = "Collect all the chests containing artefacts.";
    string findArtefactsTip = "Remember to read the description, it will be on the test.";
    string artefactQuiz = "Go back to Lady Lepidina to give her slippers back and get ready for the quiz.";
    string artefactTip = "Press the 1 key to open up information about the artefacts.";
    string vulcanusQuiz = "Speak with Vulcanus the Blacksmith.";
    string vulcanusTip = "The blacksmith is by the western gate.";
    string armatusQuiz = "Speak with Armatus the Master at Arms.";
    string armatusTip = "Armatus is found to the east of the blacksmith";
    string priestQuiz = "Speak with Marcus Flavus the Priest.";
    string priestTip = "The priest can be found to the east of the bathhouse.";

    public List<Goal>goals = new List<Goal>();

    public enum FortObjective
    {
        IntroduceCommander,
        Tutorial,
        SpeakWithCommander,
        SpeakWithBathHouse,
        GetLumber, 
        FindArtefacts,
        AretefactsQuiz,
        BattleQuiz,
        WeaponsQuiz, 
        GodsQuiz

    }
    bool areFortQuestsComplete = false;

    public bool AreFortQuestsComplete()
    {
        return areFortQuestsComplete;
    }

    public void SetObjectivecomplete(FortObjective objective)
    {

        int index = (int)objective;
        goals[index].Complete = true;
        FindCurrentObjective();
        index = (int)currentObjective;
        InitialiseCurrentObjective(index);

    }

    FortObjective currentObjective;
    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        currentObjective = FortObjective.IntroduceCommander;

        AddGoal(introduceCommander, introduceCommanderTip);
        AddGoal(tutorial, tutorialTip);
        AddGoal(speakWithCommander, speakWithCommanderTip);
        AddGoal(speakWithBathhouse, speakWithBathhouseTip);
        AddGoal(getLumber, getLumberTip);
        AddGoal(findArtefacts, findArtefactsTip);
        AddGoal(artefactQuiz, artefactTip);
        AddGoal(armatusQuiz, armatusTip);
        AddGoal(vulcanusQuiz, vulcanusTip);
        AddGoal(priestQuiz, priestTip);

        InitialiseCurrentObjective((int)currentObjective);
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
            else if(i == size - 1)
            {
                areFortQuestsComplete = true;
            }
            
        }
        
    }

    void Update()
    {

    }

    string objPrefix = "Objective: ";
    void InitialiseCurrentObjective(int index)
    {
        UIManager.Instance.Objective.text = objPrefix + goals[index].Objective;
        UIManager.Instance.Tip.text = goals[index].Tip;
    }
}
