using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TabletManager : Singleton<TabletManager>
{
    Typer typer;
    public Tablet[] tablets;

    [SerializeField]
    Canvas tabletCanvas;

    public TMP_Text tabletText;
    public TMP_Text outputText;

    public int currentTablet;

    bool IsTabletCanvasActive = false;

    protected override void Awake()
    {
        base.Awake();
        currentTablet = 0;
        typer = new Typer();
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
        typer.SplitTabletMessage(tablets[currentTabletIndex]);
        IsTabletCanvasActive=true;
        tabletCanvas.gameObject.SetActive(IsTabletCanvasActive);
    }

}
