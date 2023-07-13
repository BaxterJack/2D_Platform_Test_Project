using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitalis : NPC
{
    protected static Vitalis instance;
    GameManager gameManager;
    private void Awake()
    {

        stateMachine = new StateMachine();

      
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
//        stateMachine.SetInitialState(flaviusWelcomeState);


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
