using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulcaniusQuiz : BaseState
{
    Dialogue dialogue;
    int count = 0;
    public VulcaniusQuiz(NPC npc) : base(npc)
    {
        string sentence1 = "I have a challenge for you. Let me test you on your knowledge of Roman weapons and armmour.";
        string sentence2 = "If you do well, I'll make some improvements to your armour to make them lighter and speed you up!";
        string sentence3 = "Are you ready? Lets go!";
        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.HasTabletPuzzle = false;
        dialogue.ConversationComplete = false;
        dialogue.ForcedDialogue = false;
        dialogue.name = "Valerius Vulcanius";


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
            GameManager.Instance.InstatiateQuiz("WeaponsQuiz", QuizManager.QuizType.Weaponary);
        }
    }

    public override void FixedUpdateState()
    {

    }
}
