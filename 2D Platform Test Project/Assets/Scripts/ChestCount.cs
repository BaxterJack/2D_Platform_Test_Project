using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCount : MonoBehaviour
{

    void Start()
    {

        int count = transform.childCount;
        ArtefactCanvasManager manager = ArtefactCanvasManager.Instance;
        manager.NumChests = count;
        manager.ClearChests();
        for (int i = 0; i < count; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.CompareTag("Chest"))
            {
                manager.AddChest(child);
                child.SetActive(false);
            }
        }

    }

   
}
