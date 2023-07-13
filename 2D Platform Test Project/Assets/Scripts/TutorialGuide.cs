using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialGuide : MonoBehaviour
{
    public GameObject leftMouse;
    public GameObject rightMouse;
    public GameObject space;
    public GameObject a;
    public GameObject d;
    public GameObject button;
    public TMP_Text instruction;

    public HealthBar axeHealth;
    public HealthBar bowHealth;
    public HealthBar playerHealth;

    string moveLeft = "Try moving Left";
    string moveRight = "Try moving Right";
    string jump = "Try Jumping";
    string stab = "Try the quick stab attack, performs minor damgage";
    string slash = "Try the heavy slash attack, performs major damgage";
    string barbAxeman = "Try taking out the barbarian axeman. Try and dodge their attack when they pull their axe back, then counterattack.";
    string barbBowmen = "Try taking out the barbarian bowmen. Try and jump over their arrows, then go in for an attack.";
    string complete = "You'll make a fine soldier thats for sure";

    enum Objective
    {
        MoveLeft,
        MoveRight,
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
        instruction.text = moveLeft;
        currentObjective = Objective.MoveLeft;
        PlayerManager.Instance.CanAttack = true;
    }

    
    void Update()
    {
        switch (currentObjective)
        {
            case Objective.MoveLeft:
                instruction.text = moveLeft;
                a.SetActive(true);
                if(Input.GetKeyDown(KeyCode.A))
                {
                    a.SetActive(false);
                    currentObjective = Objective.MoveRight;
                }
                break;
            case Objective.MoveRight:
                instruction.text = moveRight;
                d.SetActive(true);
                if (Input.GetKeyDown(KeyCode.D))
                {
                    d.SetActive(false);
                    currentObjective = Objective.Jump;
                }
                break;
            case Objective.Jump:
                instruction.text = jump;
                space.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    space.SetActive(false);
                    currentObjective = Objective.Stab;
                }
                break;
            case Objective.Stab:
                instruction.text = stab;
                leftMouse.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    leftMouse.SetActive(false);
                    currentObjective = Objective.Slash;
                }
                break;
            case Objective.Slash:
                instruction.text = slash;
                rightMouse.SetActive(true);
                if (Input.GetMouseButtonDown(1))
                {
                    rightMouse.SetActive(false);
                    currentObjective = Objective.BarbAxeman;
                }
                break;
            case Objective.BarbAxeman:
                instruction.text = barbAxeman;
                if (axeHealth.HasNoHealth())
                {
                    currentObjective = Objective.BarbBowmen;
                }

                break;
            case Objective.BarbBowmen:
                instruction.text = barbBowmen;
                if (bowHealth.HasNoHealth())
                {
                    currentObjective = Objective.Complete;
                }
                break;

            case Objective.Complete:
                instruction.text = complete;
                PlayerManager.Instance.CanAttack = false;
                button.SetActive(true);
                break;
        }
    }

    public void ExitTrainingGround()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneState.Fort);
        GameManager.Instance.TutorialComplete = true;
        GameManager.Instance.ActivateNPCS(true);
        PlayerManager.Instance.SetFortPosition();
    }
}
