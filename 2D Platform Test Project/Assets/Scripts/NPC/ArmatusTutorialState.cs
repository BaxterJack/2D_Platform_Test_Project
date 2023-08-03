using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatusTutorialState : BaseState
{

    public ArmatusTutorialState(NPC npc) : base(npc)
    {

    }
    public override void EnterState()
    {
        GameManager.Instance.SaveFortPosition();
        GameSceneManager.Instance.LoadNextLevel(GameSceneManager.SceneState.DemoLevel);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
