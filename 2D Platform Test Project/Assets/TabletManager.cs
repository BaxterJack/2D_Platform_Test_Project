using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System.Linq;

public class TabletManager : Singleton<TabletManager>
{
    Typer typer;
    public Tablet[] tablets;

    [SerializeField]
    Canvas tabletCanvas;

    public TMP_Text tabletText;
    public TMP_Text outputText;

    public Color translatedColour;
    

    public int currentTablet;

    bool IsTabletCanvasActive = false;

    int completedLetterIndex = 0;



    protected override void Awake()
    {
        base.Awake();
        currentTablet = 0;
        typer = new Typer();
        translatedTabletText = new StringBuilder();
        remainingTabletText = new StringBuilder();
    }

    private void Update()
    {
        if(IsTabletCanvasActive)
        {
            typer.Update();
            outputText.text = typer.WordOutput;
        }

    }

    public void InitialiseMessage(int currentTabletIndex)
    {
        tabletText.text = tablets[currentTabletIndex].message;
        remainingTabletText.Clear();
        translatedTabletText.Clear();
        remainingTabletText.Append(tabletText.text);
        typer.SplitTabletMessage(tablets[currentTabletIndex]);
        IsTabletCanvasActive = true;
        completedLetterIndex = 0;
        tabletCanvas.gameObject.SetActive(IsTabletCanvasActive);
    }

    StringBuilder translatedTabletText;
    StringBuilder remainingTabletText;

    string colourTag = "<color=#006400>"; // Green Colour
    string endColourTag = "</color>";
    char[] ignoreChars = { '.', ',', ';', '!', '?', ' ' };
    public void ChangeCompletedLetterColour()
    {
        //remove first character from remainingTabletText
        //check if next character in remainingTabletText is not a space or punctuation
        //if next charachter is space/punctution, keep looking until next lett char
        //add this/these characters to translatedTabletText
        if (remainingTabletText.Length > 0)
        {
            char firstChar = remainingTabletText[0];
            remainingTabletText.Remove(0, 1);
            translatedTabletText.Append(firstChar);
            while (remainingTabletText.Length > 0 && ignoreChars.Contains(remainingTabletText[0]))
            {
                char removeChar = remainingTabletText[0];
                remainingTabletText.Remove(0, 1);
                translatedTabletText.Append(removeChar);
            }
        }
        //add colour to translatedTabletText
        //concatenate translatedTabletText & remainingTabletText to tabletText.text
        tabletText.text = colourTag + translatedTabletText.ToString() + endColourTag + remainingTabletText.ToString() ;
    }

}


//do
//{
//    char removeChar = remainingTabletText[0];
//    remainingTabletText.Remove(0, 1);
//    translatedTabletText.Append(removeChar);
//} while (ignoreChars.Contains(remainingTabletText[0]));