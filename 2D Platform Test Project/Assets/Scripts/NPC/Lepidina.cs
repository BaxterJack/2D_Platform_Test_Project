using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lepidina : NPC
{
    GameManager gameManager;

    private static Lepidina instance;


    private void Awake()
    {
        stateMachine = new StateMachine();



        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<Lepidina>();
        DontDestroyOnLoad(gameObject);
    }


    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        //stateMachine.AddTransition(new StateTransition(priestQuizState, priestTeachState, gameManager.IsGodsQuizComplete));
        //stateMachine.SetInitialState(priestSendToTraining);
        type = npcTypes.fort;
    }

    private void Update()
    {
        //stateMachine.Update();
    }

    private void FixedUpdate()
    {
        //stateMachine.FixedUpdate();
    }
}
