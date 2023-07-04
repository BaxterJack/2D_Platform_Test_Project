using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtefactCanvasManager : Singleton<ArtefactCanvasManager>
{
    public Canvas artefactCanvas;
    public TMP_Text artefactName;
    public TMP_Text artefactDescription;
    public Image artefactImage;

    public void OpenCanvas(Artefact artefact)
    {
        artefactName.text = artefact.name;
        artefactDescription.text = artefact.description;
        artefactImage.sprite = artefact.image;
        artefactCanvas.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        artefactCanvas.gameObject.SetActive(false);
    }
}
