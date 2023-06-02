using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : Singleton<GameSceneManager>
{
    SceneState currentSceneState;
    public enum SceneState
    {
        MainMenu,
        Fort,
        Level1,
        DemoLevel
    }

    void Start()
    {
        currentSceneState = SceneState.MainMenu;
    }


    void Update()
    {
        //Debug.Log(GameSceneManager.Instance.CurrentScene);
    }

    public void LoadScene(SceneState sceneName)
    {
        currentSceneState = sceneName;
        string sceneNameString = sceneName.ToString();
        SceneManager.LoadScene(sceneNameString);
    }

    public SceneState CurrentScene
    {
        get { return currentSceneState; }
    }
}
