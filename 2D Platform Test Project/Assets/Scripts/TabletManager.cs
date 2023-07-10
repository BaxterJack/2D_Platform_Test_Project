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

    //[SerializeField]
    //Canvas tabletCanvas;

    //public Button closeButton;
    //public TMP_Text tabletText;
    //public TMP_Text outputText;

    //public TMP_Text title;




    Button closeButton;
    TMP_Text tabletText;
    TMP_Text translatedText;
    TMP_Text title;
    Canvas canvas;


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


        //test
        closeButton = GetComponentInChildren<Button>();
        tabletText = GetComponentInChildren<TMP_Text>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = isTabletCanvasActive;
        closeButton.gameObject.SetActive(false);
        foreach (TMP_Text textComponent in GetComponentsInChildren<TMP_Text>())
        {
            switch (textComponent.name)
            {
                case "Tablet Text":
                    tabletText = textComponent;
                    break;
                case "Translated Text":
                    translatedText = textComponent;
                    break;
                case "Title":
                    title = textComponent;
                    break;
            }
        }

    }

    private void Update()
    {
        if(isTabletCanvasActive)
        {
            typer.Update();
            translatedText.text = typer.WordOutput;
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

        //tabletCanvas.gameObject.SetActive(isTabletCanvasActive); test
        //gameObject.SetActive(isTabletCanvasActive); //test
        canvas.enabled = isTabletCanvasActive; // test 2
        UIManager.Instance.HideUI();
        title.text = "Writing Tablet Mystery: Can you translate the message?";


    }


    public void ChangeCompletedLetterColour()
    {
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
        isTabletCanvasActive = false;
        canvas.enabled = isTabletCanvasActive; // test 2       
        UIManager.Instance.ShowUI();
    }

}

