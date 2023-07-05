using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flavius : NPC
{
    FlaviusWelcomeState flaviusWelcomeState;
    GoToCommandersHouseState goToCommandersHouseState;
    private void Awake()
    {
        stateMachine = new StateMachine();
        flaviusWelcomeState = new FlaviusWelcomeState(this);
        stateMachine.SetInitialState(flaviusWelcomeState);
        goToCommandersHouseState = new GoToCommandersHouseState(this);
        stateMachine.AddTransition(new StateTransition(flaviusWelcomeState, goToCommandersHouseState, this.GetHasConversationCompleted));
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
