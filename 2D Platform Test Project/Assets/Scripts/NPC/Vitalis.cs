using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitalis : NPC
{
    protected static Vitalis instance;
    GameManager gameManager;
    VitalisSendToTraining vitalisSendToTraining;
    VitalisLumberQuest vitalisLumberQuest;
    VitalisBathHouseComplete vitalisBathHouseComplete;
    private void Awake()
    {

        stateMachine = new StateMachine();
        vitalisSendToTraining = new VitalisSendToTraining(this);
        vitalisLumberQuest = new VitalisLumberQuest(this);
        vitalisBathHouseComplete = new VitalisBathHouseComplete(this);
        homeWaypoint = gameObject.transform.position;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<Vitalis>();
        DontDestroyOnLoad(gameObject);
    }


    protected override void Start()
    {
        base.Start();
        gameManager = GameManager.Instance;
        stateMachine.SetInitialState(vitalisSendToTraining);
        stateMachine.AddTransition(new StateTransition(vitalisSendToTraining, vitalisLumberQuest, gameManager.IsTutorialComplete));
        stateMachine.AddTransition(new StateTransition(vitalisLumberQuest, vitalisBathHouseComplete, gameManager.IsBathHouseConstructed));
        type = npcTypes.fort;

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
