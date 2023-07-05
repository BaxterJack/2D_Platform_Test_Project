using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name;

//    [TextArea(3 , 10)]
//    public string[] sentences;

    [TextArea(3, 10)]
    public List<string> sentences;

    public bool HasTabletPuzzle;


    public Dialogue()
    {
        sentences = new List<string>();
        name = string.Empty;
        HasTabletPuzzle = new bool();
    }
}
