using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class God 
{
    protected string name;
    protected string description;
    protected Image image;


    protected God(string Name, string Description)
    {
        name = Name;
        description = Description;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

}
