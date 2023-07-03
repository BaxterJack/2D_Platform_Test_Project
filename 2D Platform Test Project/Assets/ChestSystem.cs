using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSystem : MonoBehaviour
{
    public Artefact artefact;
    ArtefactCanvasManager artefactCanvasManager;
    Chest chest;

    private void Awake()
    {
        chest = GetComponent<Chest>();

    }
    private void Start()
    {
        artefactCanvasManager = ArtefactCanvasManager.Instance;
    }
    private void Update()
    {
        chest.IsOpened = false;
    }

    void ToggleChestState()
    {
        bool isOpen = chest.IsOpened;
        chest.IsOpened = !isOpen;
    }

    void OpenChest()
    {
        chest.IsOpened = true;
        artefactCanvasManager.OpenCanvas(artefact);
    }

    void CloseCanvas()
    {
        artefactCanvasManager.CloseCanvas();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Open Chest?");
                OpenChest();
            }
        }
    }
}
