using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : NPC
{
    GameManager gameManager;
    private static Priest instance;
    PriestWelcomeState priestWelcomeState;
    PriestQuizState priestQuizState;
    private void Awake()
    {
        stateMachine = new StateMachine();
        
        priestWelcomeState = new PriestWelcomeState(this);
        priestQuizState = new PriestQuizState(this);
        homeWaypoint = gameObject.transform.position;
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<Priest>();
        DontDestroyOnLoad(gameObject);
    }


    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        
        stateMachine.AddTransition(new StateTransition(priestWelcomeState, priestQuizState, gameManager.IsTutorialComplete));
        stateMachine.SetInitialState(priestWelcomeState);
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
