using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class God 
{
    [SerializeField]
    protected string name;
    [SerializeField]
    [TextArea(3, 10)]
    protected string description;
    [SerializeField]
    protected Sprite image;


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

    public Sprite Image
    {
        get { return image; }
    }

}
