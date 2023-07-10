using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiusArmatus : NPC
{
    GameSceneManager gameSceneManager;
    ArmatusWelcomeState armatusWelcomeState;
    ArmatusTutorialState armatusTutorialState;
    ArmatusSendToCommanderState armatusSendToCommanderState;
    ArmatusTeachState armatusTeachState;
    GameManager gameManager;


    protected static GaiusArmatus instance; 

    private void Awake()
    {
        gameSceneManager = GameSceneManager.Instance;
        gameManager = GameManager.Instance;
        stateMachine = new StateMachine();
        armatusWelcomeState = new ArmatusWelcomeState(this);
        armatusTutorialState = new ArmatusTutorialState(this);
        armatusSendToCommanderState = new ArmatusSendToCommanderState(this);
        armatusTeachState = new ArmatusTeachState(this);
        stateMachine.AddTransition(new StateTransition(armatusWelcomeState, armatusTutorialState, this.GetHasConversationCompleted));
        stateMachine.AddTransition(new StateTransition(armatusTutorialState, armatusSendToCommanderState, gameManager.IsTutorialComplete));
        stateMachine.AddTransition(new StateTransition(armatusSendToCommanderState, armatusTeachState, this.GetHasConversationCompleted));

        homeWaypoint = gameObject.transform.position;


        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<GaiusArmatus>();
        DontDestroyOnLoad(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.SetInitialState(armatusWelcomeState);
        Debug.Log("Hello Gaius Armatus");
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
