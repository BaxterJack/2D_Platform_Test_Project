using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestartLevelButton : MonoBehaviour
{
    public void RestartLevel()
    {
        RestartDemoLevel();
    }


    void RestartDemoLevel()
    {
        UIManager.Instance.ResetLivesUI();
        Debug.Log("Restart Level");
        Time.timeScale = 1f;
        Destroy(PlayerManager.Instance.gameObject);

        GameSceneManager.Instance.LoadNextLevel(GameSceneManager.Instance.CurrentScene);

        UIManager.Instance.DisactivateGameOverUI();
    }
}
