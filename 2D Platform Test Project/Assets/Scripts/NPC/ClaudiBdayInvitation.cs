using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaudiBdayInvitation : BaseState
{
    Dialogue dialogue;

    public ClaudiBdayInvitation(NPC npc) : base(npc)
    {
        string sentence1 = "In fact, as you're the hero of the day. I would love you to come to my birthday celebration too!";

        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.HasTabletPuzzle = false;
        dialogue.ForcedDialogue = true;
        dialogue.name = "Claudia Severa";


    }

    int count = 0;
    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
       
    }

    public override void UpdateState()
    {
        if(npc.GetHasConversationCompleted() && count == 0)
        {
            count++;
            LoadFinalScene();
        }
    }

    public override void FixedUpdateState()
    {

    }

    void LoadFinalScene()
    {
        GameSceneManager.Instance.LoadNextLevel(GameSceneManager.SceneState.FinalScene);
    }
}
