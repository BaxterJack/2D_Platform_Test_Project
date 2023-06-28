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
        PlayThemeMusic(currentSceneState);
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
        PlayThemeMusic(sceneName);
    }

    void PlayThemeMusic(SceneState sceneName)
    {
        AudioManager audioManager = AudioManager.instance;
        audioManager.StopTheme();
        switch (sceneName)
        {
            case SceneState.MainMenu:
                audioManager.PlayTheme("MainMenuTheme");
                break;

            case SceneState.Fort:

                break;

            case SceneState.DemoLevel:
                audioManager.PlayTheme("BattleTheme");
                break;

        }

    }


    public SceneState CurrentScene
    {
        get { return currentSceneState; }
    }
}
