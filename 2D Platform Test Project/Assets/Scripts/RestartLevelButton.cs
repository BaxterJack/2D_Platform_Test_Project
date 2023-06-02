using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestartLevelButton : MonoBehaviour
{
    public void RestartLevel()
    {
        Debug.Log("Restart Level");
        GameSceneManager.Instance.LoadScene(GameSceneManager.Instance.CurrentScene);
    }
}
