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

    public Button closeButton;
    public TMP_Text tabletText;
    public TMP_Text outputText;

    public TMP_Text title;

    public int currentTablet;
    int totalTablets;

    bool isTabletCanvasActive = false;

    StringBuilder translatedTabletText;
    StringBuilder remainingTabletText;

    string colourTag = "<color=#006400>"; // Green Colour
    string endColourTag = "</color>";
    char[] ignoreChars = { '.', ',', ';', '!', '?', ' ' };

    public bool IsTabletCanvasActive
    {
        get {  return isTabletCanvasActive; }
    }
    protected override void Awake()
    {
        base.Awake();
        currentTablet = 0;
        typer = new Typer();
        translatedTabletText = new StringBuilder();
        remainingTabletText = new StringBuilder();
        totalTablets = tablets.Length;
    }

    private void Update()
    {
        if(isTabletCanvasActive)
        {
            typer.Update();
            outputText.text = typer.WordOutput;
        }

    }

    public void InitialiseTablet()
    {
        tabletText.text = tablets[currentTablet].message;
        remainingTabletText.Clear();
        translatedTabletText.Clear();
        remainingTabletText.Append(tabletText.text);
        typer.SplitTabletMessage(tablets[currentTablet]);
        isTabletCanvasActive = true;
        tabletCanvas.gameObject.SetActive(isTabletCanvasActive);
        title.text = "Writing Tablet Mystery: Can you translate the message?";
    }


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

    public void TabletTranslated()
    {
        closeButton.gameObject.SetActive(true);
        title.text = "Congratulations! You translated the Tablet.";
    }

    public void CloseTabletUI()
    {
        closeButton.gameObject.SetActive(false);
        tabletCanvas.gameObject.SetActive(false);
        isTabletCanvasActive = false;
    }

}

