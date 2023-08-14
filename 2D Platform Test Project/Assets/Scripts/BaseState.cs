using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected AiObject aiObject;
    protected BaseState(AiObject AiObject)
    {
        aiObject = AiObject;
    }
    protected NPC npc;
    protected BaseState(NPC NPC)
    {
        npc = NPC;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void FixedUpdateState();


}
