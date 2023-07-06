using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneState.Fort);
    }
}
