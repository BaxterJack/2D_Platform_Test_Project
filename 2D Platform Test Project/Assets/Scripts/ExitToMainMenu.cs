using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitToMainMenu : MonoBehaviour
{
    public void ExitToMain()
    {
        Debug.Log("Exit to Main Menu");
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneState.MainMenu);
    }
}
