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
        stateMachine.SetInitialState(flaviusWelcomeState);
        goToCommandersHouseState = new GoToCommandersHouseState(this);
        stateMachine.AddTransition(new StateTransition(flaviusWelcomeState, goToCommandersHouseState, this.GetHasConversationCompleted));
        //DontDestroyOnLoad(this);
        gameSceneManager = GameSceneManager.Instance;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<Flavius>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //Debug.Log(stateMachine.currentState);
        if(gameSceneManager.CurrentScene == GameSceneManager.SceneState.Fort)
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
