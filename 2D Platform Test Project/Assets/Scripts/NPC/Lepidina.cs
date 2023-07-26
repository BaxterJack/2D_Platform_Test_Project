using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lepidina : NPC
{
    GameManager gameManager;

    private static Lepidina instance;
    ClaudiaGoToPlayer goToPlayer;
    LepidinaArtefactQuest artefactQuest;

    GoHome goHome;

    private void Awake()
    {
        stateMachine = new StateMachine();
        goToPlayer = new ClaudiaGoToPlayer(this);
        artefactQuest = new LepidinaArtefactQuest(this);
        goHome = new GoHome(this);
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<Lepidina>();
        DontDestroyOnLoad(gameObject);
        GameObject gO = GameObject.Find("LepidinaWaypoint");
        homeWaypoint = gO.transform.position;
    }


    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        type = npcTypes.fort;
        stateMachine.AddTransition(new StateTransition(goToPlayer, artefactQuest, this.HasReachedDestination));
        stateMachine.AddTransition(new StateTransition(artefactQuest, goHome, this.GetHasConversationCompleted));

        stateMachine.SetInitialState(goToPlayer);
    }

    private void Update()
    {
        stateMachine.Update();
        DistanceToDestination = SetDistance(destinationWaypoint);
        DistanceToHome = SetDistance(homeWaypoint);
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
}
