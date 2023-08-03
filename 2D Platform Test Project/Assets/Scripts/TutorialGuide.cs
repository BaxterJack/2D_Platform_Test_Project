using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TutorialGuide : MonoBehaviour
{
    public HealthBar axeHealth;
    public HealthBar bowHealth;
    public HealthBar playerHealth;

    string jump = "Try Jumping";
    string jumpTip = "Space: Jump";
    string stab = "Try the quick stab attack, performs minor damgage";
    string stabTip = "Left Mouse Click: Stab";
    string slash = "Try the heavy slash attack, performs major damgage";
    string slashTip = "Right Mouse Click: Slash";
    string barbAxeman = "Take out the barbarian axeman.";
    string barbAxeTip = "Try and dodge their attack when they pull their axe back, then counterattack.";
    string barbBowmen = "Take out the barbarian bowmen.";
    string barbBowTip = "Try and jump over their arrows, then go in for an attack.";


    string complete = "You'll make a fine soldier thats for sure";

    public List<Goal> goals = new List<Goal>();

    enum Objective
    {
        Jump,
        Stab,
        Slash,
        BarbAxeman,
        BarbBowmen,
        Complete
    }
    Objective currentObjective;

    void Start()
    {
        currentObjective = Objective.Jump;
        PlayerManager.Instance.CanAttack = true;

        AddGoal(jump, jumpTip);
        AddGoal(stab, stabTip);
        AddGoal(slash, slashTip);
        AddGoal(barbAxeman, barbAxeTip);
        AddGoal(barbBowmen, barbBowTip);

        Button button = UIManager.Instance.ContinueButton.GetComponent<Button>();

        button.onClick.AddListener(ExitTrainingGround);

    }



    void AddGoal(string Objective, string Tip)
    {
        goals.Add(new Goal(Objective, Tip));
    }


    void FindCurrentObjective()
    {
        int size = goals.Count;
        for(int i = 0; i < size; i++)
        {
            if (goals[i].Complete == false)
            {
                currentObjective = (Objective)i;
                break;
            }
        }
    }



    string objPrefix = "Objective: ";
    void Update()
    {
        FindCurrentObjective();
        int index = (int)currentObjective;
        switch (currentObjective)
        {
            
            case Objective.Jump:
                UIManager.Instance.Objective.text = objPrefix + goals[index].Objective;
                UIManager.Instance.Tip.text = goals[index].Tip;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    goals[index].Complete = true;
                    currentObjective = Objective.Stab;
                }
                break;

            case Objective.Stab:
                UIManager.Instance.Objective.text = objPrefix + goals[index].Objective;
                UIManager.Instance.Tip.text = goals[index].Tip;

                if (Input.GetMouseButtonDown(0))
                {
                    goals[index].Complete = true;
                    currentObjective = Objective.Slash;
                }
                break;
            case Objective.Slash:
                UIManager.Instance.Objective.text = objPrefix + goals[index].Objective;
                UIManager.Instance.Tip.text = goals[index].Tip;
                if (Input.GetMouseButtonDown(1))
                {
                    goals[index].Complete = true;
                    currentObjective = Objective.BarbAxeman;
                }
                break;
            case Objective.BarbAxeman:
                UIManager.Instance.Objective.text = objPrefix + goals[index].Objective;
                UIManager.Instance.Tip.text = goals[index].Tip;
                if (axeHealth.HasNoHealth())
                {
                    goals[index].Complete = true;
                    currentObjective = Objective.BarbBowmen;
                }

                break;
            case Objective.BarbBowmen:
                UIManager.Instance.Objective.text = objPrefix + goals[index].Objective;
                UIManager.Instance.Tip.text = goals[index].Tip;
                if (bowHealth.HasNoHealth())
                {
                    goals[index].Complete = true;
                    currentObjective = Objective.Complete;
                }
                break;

            case Objective.Complete:
                UIManager.Instance.Objective.text = objPrefix + complete;
                UIManager.Instance.Tip.text = "";
                PlayerManager.Instance.CanAttack = false;
                GameObject continueButton =  UIManager.Instance.ContinueButton;
                continueButton.SetActive(true);
                

                break;
        }
    }


    public void ExitTrainingGround()
    {
        GameManager.Instance.TutorialComplete = true;
        GameSceneManager.Instance.LoadNextLevel(GameSceneManager.SceneState.Fort);
        //StartCoroutine(InitNextScene());

    }

    IEnumerator InitNextScene()
    {
        Debug.Log(1);
        yield return new WaitForSeconds(0.75f);
        Debug.Log(2);
        
        GameManager.Instance.ActivateNPCS(true);
        GameManager.Instance.SetFortPosition();
        Debug.Log(3);
    }

}
