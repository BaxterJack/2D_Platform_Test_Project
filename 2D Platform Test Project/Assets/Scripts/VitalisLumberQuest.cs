using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VitalisLumberQuest : BaseState
{
    Dialogue dialogue;

    public VitalisLumberQuest(NPC npc) : base(npc)
    {
        string sentence1 = "Hello, I am Vitalis. Im in charge of the Bath House, or will be when its finished!";
        string sentence2 = "Whats this message then? Oh, the commander is complaining about the progress of the bathouse construction?!";
        string sentence3 = "Well, seeing as there are no raiders about, this sounds like soldiers work.";
        string sentence4 = "Being a soldier here at Vindolanda isn't just fighting remember. You also provide maintenance, construction and any other day to day tasks to keep this fort operating.";
        string sentence5 = "All we need to fiish the bath house is Lumber. If you go out the eastern gate, there are some trees there ready for felling";
        string sentence6 = "Bring back a log and dump it back here in front of the construction site.";


        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.sentences.Add(sentence4);
        dialogue.sentences.Add(sentence5);
        dialogue.sentences.Add(sentence6);
        dialogue.HasTabletPuzzle = false;
        dialogue.name = "Vitalis";


    }

    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
