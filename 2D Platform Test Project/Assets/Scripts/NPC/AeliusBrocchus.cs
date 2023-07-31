using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeliusBrocchus : NPC
{
    GameManager gameManager;
    BrocchusClearRaiders clearRaiders;
    BrocchusRaidersCleared raidersCleared;
    BrocchusIntroduceClaudia introduceClaudia;
    BrocchusEndDialogue endDialogue;
    public GameObject claudiaPrefab;
    private void Awake()
    {
        stateMachine = new StateMachine();
        clearRaiders = new BrocchusClearRaiders(this);
        raidersCleared = new BrocchusRaidersCleared(this);
        introduceClaudia = new BrocchusIntroduceClaudia(this);
        endDialogue = new BrocchusEndDialogue(this);
        type = npcTypes.level1;
    }
    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        
        stateMachine.SetInitialState(clearRaiders);
        stateMachine.AddTransition(new StateTransition( clearRaiders, raidersCleared, gameManager.AreRaidersCleared));
        stateMachine.AddTransition(new StateTransition(raidersCleared, introduceClaudia, this.GetHasConversationCompleted));
        stateMachine.AddTransition(new StateTransition(introduceClaudia, endDialogue, this.GetHasConversationCompleted));
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

    public void SpawnClaudia()
    {
        GameObject instantiatedPrefab = Instantiate(claudiaPrefab);
        instantiatedPrefab.transform.position = new Vector3(95f, -2.7f, 0f);
        instantiatedPrefab.transform.rotation = Quaternion.identity;
        
    }
}

