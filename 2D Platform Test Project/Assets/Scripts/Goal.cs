using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal 
{
    public Goal(string Objective, string Tip)
    {
        objective = Objective;
        tip = Tip;
        isComplete = false;
    }

    [SerializeField]
    private string objective;
    [SerializeField]
    private string tip;
    [SerializeField]
    private bool isComplete = false;

    public string Objective
    {
        get { return objective; }
        set { objective = value; }
    }

    public string Tip
    {
        get { return tip; }
        set {  tip = value;}
    }

    public bool Complete
    {
        get { return isComplete; }
        set { isComplete = value; }
    }
}
