using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtefactCanvasManager : Singleton<ArtefactCanvasManager>
{
    Canvas artefactCanvas;
    TMP_Text artefactName;
    TMP_Text artefactDescription;
    Image artefactImage;


    protected override void Awake()
    {
        base.Awake();
        artefactCanvas = GetComponent<Canvas>();
        CloseCanvas();

        artefactImage = GetComponentInChildren<Image>();
        foreach (TMP_Text textComponent in GetComponentsInChildren<TMP_Text>())
        {
            switch (textComponent.name)
            {
                case "Artefact Name":
                    artefactName = textComponent;
                    break;
                case "Artefact Description":
                    artefactDescription = textComponent;
                    break;
            }
        }

        foreach(Image image in GetComponentsInChildren<Image>())
        {
            if (image.name == "Artefact Image")
            {
                artefactImage = image;
            }
        }
    }
    public void OpenCanvas(Artefact artefact)
    {
        artefactName.text = artefact.name;
        artefactDescription.text = artefact.description;
        artefactImage.sprite = artefact.image;
        EnableCanvas();
       
    }

    void EnableCanvas()
    {
        artefactCanvas.enabled = true;
    }

    public void CloseCanvas()
    {
        artefactCanvas.enabled = false;
    }
}
