using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaviusClearRaidersQuest : BaseState
{
    Dialogue dialogue;
    int count = 0;
    public FlaviusClearRaidersQuest(NPC npc) : base(npc)
    {
        string sentence1 = "You heard the horn right?!";
            string sentence2 = "We've had word from Fort New Newbrough that there are raiders!";
        string sentence3 = "As you've proved yourself, please can you go clear these raiders out.";
        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.HasTabletPuzzle = false;
        dialogue.name = "Flavius Cerialis";
        dialogue.ForcedDialogue = true;
    }


    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
        Rigidbody2D rB = npc.GetComponent<Rigidbody2D>();
        rB.velocity = Vector3.zero;
    }

    public override void UpdateState()
    {
        if(npc.GetHasConversationCompleted() && count == 0)
        {
            count++;
            PlayerManager.Instance.SaveFortPosition();
            GameSceneManager.Instance.LoadNextLevel(GameSceneManager.SceneState.Level1);
        }
    }

    public override void FixedUpdateState()
    {


    }
}
