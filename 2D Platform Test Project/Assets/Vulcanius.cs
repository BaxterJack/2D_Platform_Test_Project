using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcanius : NPC
{
    GameManager gameManager;
    protected static Vulcanius instance;

    VulcaniusWelcome welcome;
    VulcaniusQuiz quiz;
    VulcaniusReward reward;

    private void Awake()
    {
        stateMachine = new StateMachine();
        welcome = new VulcaniusWelcome(this);
        quiz = new VulcaniusQuiz(this);
        reward = new VulcaniusReward(this);
        homeWaypoint = gameObject.transform.position;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<Vulcanius>();
        DontDestroyOnLoad(gameObject);
    }
    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        stateMachine.SetInitialState(welcome);
        stateMachine.AddTransition(new StateTransition(welcome, quiz, gameManager.IsTutorialComplete));
        stateMachine.AddTransition(new StateTransition(quiz, reward, gameManager.IsWeaponQuizComplete));
    }

    private void Update()
    {
           stateMachine.Update();
    }

    private void FixedUpdate()
    {
           stateMachine.FixedUpdate();
    }
}
