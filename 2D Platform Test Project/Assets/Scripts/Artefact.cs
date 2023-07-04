using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Artefact 
{
    public string name;
    [TextArea(3, 10)]
    public string description;
    public Sprite image;
    
}
