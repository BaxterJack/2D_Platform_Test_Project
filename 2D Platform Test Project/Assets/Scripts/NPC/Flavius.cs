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
    FlaviusGoToPlayer goToPlayer;
    FlaviusClearRaidersQuest clearRaiders;
    protected static Flavius instance;
    private void Awake()
    {
        
        stateMachine = new StateMachine();
        
        flaviusWelcomeState = new FlaviusWelcomeState(this);
        goToCommandersHouseState = new GoToCommandersHouseState(this);
        flaviusTabletOne = new FlaviusTabletOne(this);  
        goToPlayer = new FlaviusGoToPlayer(this);
        clearRaiders = new FlaviusClearRaidersQuest(this);
        
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
        stateMachine.AddTransition(new StateTransition(flaviusTabletOne, goToPlayer, FortGuide.Instance.AreFortQuestsComplete));
        stateMachine.AddTransition(new StateTransition(goToPlayer, clearRaiders, this.HasReachedDestination));  

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
            stateMachine.Update();
            DistanceToHome = SetDistance(homeWaypoint);

    }

    private void FixedUpdate()
    {
            stateMachine.FixedUpdate();
    }
}
