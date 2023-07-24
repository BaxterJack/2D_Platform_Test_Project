using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeliusBrocchus : NPC
{
    GameManager gameManager;
    BrocchusClearRaiders clearRaiders;
    BrocchusRaidersCleared raidersCleared;
    private void Awake()
    {
        stateMachine = new StateMachine();
        clearRaiders = new BrocchusClearRaiders(this);
        raidersCleared = new BrocchusRaidersCleared(this);
    }
    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        type = npcTypes.level1;
        stateMachine.SetInitialState(clearRaiders);
        stateMachine.AddTransition(new StateTransition( clearRaiders, raidersCleared, gameManager.AreRaidersCleared));
        homeWaypoint = gameObject.transform.position;
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
