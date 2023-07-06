using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiusArmatus : NPC
{
    GameSceneManager gameSceneManager;
    ArmatusTutorialState armatusTutorialState;
    ArmatusWelcomeState armatusWelcomeState;

    protected static GaiusArmatus instance; 

    private void Awake()
    {
        stateMachine = new StateMachine();
        armatusWelcomeState = new ArmatusWelcomeState(this);
        armatusTutorialState = new ArmatusTutorialState(this);
        stateMachine.SetInitialState(armatusWelcomeState);
        stateMachine.AddTransition(new StateTransition(armatusWelcomeState, armatusTutorialState, this.GetHasConversationCompleted));
        //DontDestroyOnLoad(this);
        gameSceneManager = GameSceneManager.Instance;


        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<GaiusArmatus>();
        DontDestroyOnLoad(gameObject);
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
