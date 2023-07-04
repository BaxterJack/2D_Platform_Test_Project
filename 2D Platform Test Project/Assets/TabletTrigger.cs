using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTrigger : MonoBehaviour
{

    public Tablet tablet;
    TabletManager tabletManager;

    void Start()
    {
        tabletManager = TabletManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerTabletPuzzle()
    {

        //tabletManager.InitialiseMessage(tablet);
    }
}
