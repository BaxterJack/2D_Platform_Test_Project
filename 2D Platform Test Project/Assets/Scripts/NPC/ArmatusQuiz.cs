using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatusQuiz : BaseState
{
    Dialogue dialogue;
    int count = 0;
    public ArmatusQuiz(NPC npc) : base(npc)
    {
        string sentence1 = "I have a challenge for you. Let me test you on your knowledge of our conquest of Britannia.";
        string sentence2 = "If you do well, I'll give you a little reward.";
        string sentence3 = "Are you ready? Lets go!";
        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.HasTabletPuzzle = false;
        dialogue.ConversationComplete = false;
        dialogue.ForcedDialogue = false;
        dialogue.name = "Gaius Armatus";


    }
    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
    }

    public override void UpdateState()
    {
        if (npc.GetHasConversationCompleted() && count == 0)
        {
            count++;
            GameManager.Instance.InstatiateQuiz("BattleQuiz", QuizManager.QuizType.BattleTactics);
        }
    }

    public override void FixedUpdateState()
    {

    }
}
