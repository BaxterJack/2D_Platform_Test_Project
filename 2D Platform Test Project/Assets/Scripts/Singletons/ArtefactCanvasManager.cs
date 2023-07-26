using Cainos.PixelArtPlatformer_VillageProps;
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

    public Chest currentChest = new Chest();

    public Chest CurrentChest {  get { return currentChest; } set { currentChest = value; } }

    public List<Artefact> collectedArtefacts = new List<Artefact>();
    public List<GameObject> chests = new List<GameObject>();

    [SerializeField]
    private int numChests = 0;

    public int NumChests
    {
        get { return numChests; }
        set { numChests = value; }
    }

    public void ClearChests()
    {
        chests.Clear();
    }
    public void AddChest(GameObject chest)
    {
        chests.Add(chest);
    }

    bool allChestsCollected = false;
    public bool AllChestsCollected()
    {
         return allChestsCollected; 
    }
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

    private void Update()
    {
        if(collectedArtefacts.Count == numChests)
        {
            allChestsCollected = true;
        }
    }
    public void AddArtefact(Artefact artefact)
    {
        collectedArtefacts.Add(artefact);
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
        UIManager.Instance.HideUI();
    }

    public void CloseCanvas()
    {
        artefactCanvas.enabled = false;
        UIManager.Instance.ShowUI();
        if(currentChest != null)
        {
            currentChest.CollectChest();
        }
        
    }

    public void ActivateChests()
    {
        foreach(GameObject g in chests)
        {
            g.SetActive(true);
        }
    }
}
