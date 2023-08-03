using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitToMainMenu : MonoBehaviour
{
    public void ExitToMain()
    {

        Time.timeScale = 1f;
        GameManager.Instance.ActivateNPCS(true);
        GetDontDestroyOnLoadObjects();

        GameSceneManager.Instance.LoadNextLevel(GameSceneManager.SceneState.MainMenu);
    }


    void GetDontDestroyOnLoadObjects()
    {
        GameObject[] dontDestroyOnLoadObjects = Object.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in dontDestroyOnLoadObjects)
        {
            if (obj.tag == "DestroyOnExit")
            {
                Debug.Log(obj.name);
            }
            if (obj.scene.name == "DontDestroyOnLoad" || obj.tag == "DestroyOnExit")
            {
                Destroy(obj);
            }

        }
    }
}