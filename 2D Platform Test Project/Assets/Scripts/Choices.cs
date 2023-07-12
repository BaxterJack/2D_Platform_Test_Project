using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//[System.Serializable]
public class Choices
{
    private bool isCorrectAnswer = new bool();
    private int index = new int();
    private Button button;
    private Image background;
    public Choices()
    {
        isCorrectAnswer = false;
        index = 0;
    }

    public bool IsCorrectAnswer
    {
        get { return isCorrectAnswer; }
        set { isCorrectAnswer = value; }
    }
    public int Index
    {
        get { return index; }
        set { index = value; }
    }
    public Button Button
    {
        get { return button; }
        set { button = value; }
    }

    public Image Background
    {
        get { return background; }
        set { background = value; }
    }

}
