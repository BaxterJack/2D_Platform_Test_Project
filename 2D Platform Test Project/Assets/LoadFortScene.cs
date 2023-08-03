using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFortScene : MonoBehaviour
{

    void Start()
    {
        if (GameManager.Instance.IsTutorialComplete())
        {
            GameManager.Instance.ActivateNPCS(true);
            GameManager.Instance.SetFortPosition();
        }
    }
}
