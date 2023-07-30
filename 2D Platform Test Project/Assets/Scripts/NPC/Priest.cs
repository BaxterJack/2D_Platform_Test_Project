using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : NPC
{
    GameManager gameManager;
    private static Priest instance;
    PriestSendToTraining priestSendToTraining;
    PriestWelcomeState priestWelcomeState;
    PriestQuizState priestQuizState;
    //    PriestTeachState priestTeachState;
    PriestReward reward;
    private void Awake()
    {
        stateMachine = new StateMachine();

        priestSendToTraining = new PriestSendToTraining(this);
        priestWelcomeState = new PriestWelcomeState(this);
        priestQuizState = new PriestQuizState(this);
       // priestTeachState = new PriestTeachState(this);
       reward = new PriestReward(this);
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
        stateMachine.AddTransition(new StateTransition(priestSendToTraining, priestWelcomeState, gameManager.IsTutorialComplete));
        stateMachine.AddTransition(new StateTransition(priestWelcomeState, priestQuizState, this.GetHasConversationCompleted));
        // stateMachine.AddTransition(new StateTransition(priestQuizState, priestTeachState, gameManager.IsGodsQuizComplete));
        stateMachine.AddTransition(new StateTransition(priestQuizState, reward, gameManager.IsGodsQuizComplete));
        stateMachine.SetInitialState(priestSendToTraining);
        type = npcTypes.fort;
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
