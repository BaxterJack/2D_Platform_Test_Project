using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestartLevelButton : MonoBehaviour
{
    public void RestartLevel()
    {
        GameManager.Instance.ResetRaiderCount();
        if(GameSceneManager.Instance.CurrentScene == GameSceneManager.SceneState.Fort)
        {
            GetDontDestroyOnLoadObjects();
            GameSceneManager.Instance.LoadNextLevel(GameSceneManager.Instance.CurrentScene);
        }
        else
        {
            UIManager.Instance.ResetLivesUI();
            Debug.Log("Restart Level");
            Time.timeScale = 1f;
            Destroy(PlayerManager.Instance.gameObject);

            GameSceneManager.Instance.LoadNextLevel(GameSceneManager.Instance.CurrentScene);

            UIManager.Instance.DisactivateGameOverUI();
        }

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
    void RestartFortLevel()
    {

    }
}
