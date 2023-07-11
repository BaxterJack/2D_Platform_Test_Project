using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flavius : NPC
{
    GameManager gameManager;
    GameSceneManager gameSceneManager;
    FlaviusWelcomeState flaviusWelcomeState;
    GoToCommandersHouseState goToCommandersHouseState;
    FlaviusTabletOne flaviusTabletOne;
    protected static Flavius instance;
    private void Awake()
    {
        
        stateMachine = new StateMachine();
        gameManager = GameManager.Instance;
        flaviusWelcomeState = new FlaviusWelcomeState(this);
        goToCommandersHouseState = new GoToCommandersHouseState(this);
        flaviusTabletOne = new FlaviusTabletOne(this);  
        stateMachine.AddTransition(new StateTransition(flaviusWelcomeState, goToCommandersHouseState, this.GetHasConversationCompleted));
        stateMachine.AddTransition(new StateTransition(goToCommandersHouseState, flaviusTabletOne, gameManager.IsTutorialComplete));
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
