using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDelegates 
{
    protected AiObject aiObject;

    public BaseDelegates(AiObject AiObject)
    {
        aiObject = AiObject;
    }
}
