using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{

    void PlayGame()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneState.Fort);
    }
}
