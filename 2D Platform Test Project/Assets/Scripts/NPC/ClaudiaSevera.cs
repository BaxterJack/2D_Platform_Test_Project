using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaudiaSevera : NPC
{
    GameManager gameManager;
    ClaudiaGoToPlayer goToPlayer;
    ClaudiaBirthdayTablet claudiaBirthdayTablet;
    ClaudiBdayInvitation birthdayInvitation;

    private void Awake()
    {
        stateMachine = new StateMachine();
        goToPlayer = new ClaudiaGoToPlayer(this);
        claudiaBirthdayTablet = new ClaudiaBirthdayTablet(this);
        birthdayInvitation = new ClaudiBdayInvitation(this);
    }
    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        type = npcTypes.level1;
        stateMachine.SetInitialState(goToPlayer);
        stateMachine.AddTransition(new StateTransition(goToPlayer, claudiaBirthdayTablet, HasReachedDestination));
        stateMachine.AddTransition(new StateTransition(claudiaBirthdayTablet, birthdayInvitation, this.GetHasConversationCompleted));
        //GameObject gO = GameObject.Find("ClaudiaWaypoint");
        //homeWaypoint = gO.transform.position;

    }

    private void Update()
    {
        stateMachine.Update();
        DistanceToDestination = SetDistance(destinationWaypoint);
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
}
