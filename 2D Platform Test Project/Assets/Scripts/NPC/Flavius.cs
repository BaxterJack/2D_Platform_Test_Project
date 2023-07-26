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
        
        flaviusWelcomeState = new FlaviusWelcomeState(this);
        goToCommandersHouseState = new GoToCommandersHouseState(this);
        flaviusTabletOne = new FlaviusTabletOne(this);  

        
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
        gameManager = GameManager.Instance;
        gameSceneManager = GameSceneManager.Instance;
        stateMachine.SetInitialState(flaviusWelcomeState);
        stateMachine.AddTransition(new StateTransition(flaviusWelcomeState, goToCommandersHouseState, this.GetHasConversationCompleted));
        stateMachine.AddTransition(new StateTransition(goToCommandersHouseState, flaviusTabletOne, FlaviusTabletCondition));
        type = npcTypes.fort;
    }

    bool FlaviusTabletCondition()
    {
        bool condition = gameManager.IsTutorialComplete();
        condition &= HasReachedHome();
        return condition;
    }


    private void Update()
    {
        if (gameSceneManager.CurrentScene == GameSceneManager.SceneState.Fort)
        {
            stateMachine.Update();
            DistanceToHome = SetDistance(homeWaypoint);
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
