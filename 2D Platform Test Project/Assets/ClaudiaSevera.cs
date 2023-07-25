using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaudiaSevera : NPC
{
    GameManager gameManager;
    ClaudiaGoToPlayer goToPlayer;
    ClaudiaBirthdayTablet claudiaBirthdayTablet;

    private void Awake()
    {
        stateMachine = new StateMachine();
        goToPlayer = new ClaudiaGoToPlayer(this);
        claudiaBirthdayTablet = new ClaudiaBirthdayTablet(this);
    }
    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        type = npcTypes.level1;
        stateMachine.SetInitialState(goToPlayer);
        stateMachine.AddTransition(new StateTransition(goToPlayer, claudiaBirthdayTablet, HasReachedDestination));
        //GameObject gO = GameObject.Find("ClaudiaWaypoint");
        //homeWaypoint = gO.transform.position;

    }

    private void Update()
    {
        stateMachine.Update();
        SetDistance();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
}
