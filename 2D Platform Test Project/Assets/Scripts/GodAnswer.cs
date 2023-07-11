using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GodAnswer : God
{
    [SerializeField]
    [TextArea(1, 10)]
    private string hint;
    GodAnswer(string Name, string Description, string Hint) : base(Name, Description)
    {
        hint = Hint;
    }

    public string Hint
    {
        get { return hint; }
        set { hint = value; }
    }
}
