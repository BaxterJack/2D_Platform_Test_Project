using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flavius : NPC
{
    GameSceneManager gameSceneManager;
    FlaviusWelcomeState flaviusWelcomeState;
    GoToCommandersHouseState goToCommandersHouseState;

    protected static Flavius instance;
    private void Awake()
    {
        
        stateMachine = new StateMachine();
        flaviusWelcomeState = new FlaviusWelcomeState(this);
        //stateMachine.SetInitialState(flaviusWelcomeState);
        goToCommandersHouseState = new GoToCommandersHouseState(this);
        stateMachine.AddTransition(new StateTransition(flaviusWelcomeState, goToCommandersHouseState, this.GetHasConversationCompleted));
        gameSceneManager = GameSceneManager.Instance;
        GameObject gO = GameObject.Find("CommandersHouseWaypoint");
        homeWaypoint = gO.transform.position;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<Flavius>();
        DontDestroyOnLoad(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.SetInitialState(flaviusWelcomeState);
    }

    private void Update()
    {
        if (gameSceneManager.CurrentScene == GameSceneManager.SceneState.Fort)
        {
            stateMachine.Update();
        }

    }

    private void FixedUpdate()
    {
        if (gameSceneManager.CurrentScene == GameSceneManager.SceneState.Fort)
        {
            stateMachine.FixedUpdate();
        }
            
    }
}
