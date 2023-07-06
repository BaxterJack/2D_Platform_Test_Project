using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiusArmatus : NPC
{
    ArmatusTutorialState armatusTutorialState;

    private void Awake()
    {
        stateMachine = new StateMachine();
        armatusTutorialState = new ArmatusTutorialState(this);
        stateMachine.SetInitialState(armatusTutorialState);
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
