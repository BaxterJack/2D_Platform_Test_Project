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
    Scene scene;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        ApplyCurrentScene(sceneName);
        ChangeThemeMusic(currentSceneState);
    }

    void ApplyCurrentScene(string sceneName)
    {
        switch (sceneName)
        {
            case "MainMenu":
                currentSceneState = SceneState.MainMenu;
                break;
            case "Fort":
                currentSceneState = SceneState.Fort;
                break;
            case "DemoLevel":
                currentSceneState = SceneState.DemoLevel;
                break;
            case "Level1":
                currentSceneState = SceneState.Level1;
                break;
        }
    }


    void Update()
    {

    }

    public void LoadScene(SceneState sceneName)
    {
        currentSceneState = sceneName;
        string sceneNameString = sceneName.ToString();
        SceneManager.LoadScene(sceneNameString);
        //ApplySceneSettings(sceneName);
        ChangeThemeMusic(sceneName);
    }

    //public void ApplySceneSettings(SceneState sceneName)
    //{
    //    switch(sceneName)
    //    {
    //        case SceneState.DemoLevel:
    //            GameObject obj = GameObject.Find("PlayerSpawn");
    //            PlayerManager playerManager = PlayerManager.Instance;
    //            playerManager.player.transform.position = obj.transform.position;
    //            break;
    //    }
    //}

    void ChangeThemeMusic(SceneState sceneName)
    {
        AudioManager audioManager = AudioManager.instance;
        audioManager.StopTheme();
        switch (sceneName)
        {
            case SceneState.MainMenu:
                audioManager.PlayTheme("MainMenuTheme");
                break;

            case SceneState.Fort:
                audioManager.PlayTheme("FortTheme");
                break;

            case SceneState.DemoLevel:
                audioManager.PlayTheme("BattleTheme");
                break;

            case SceneState.Level1:
                audioManager.PlayTheme("BattleTheme2");
                break;
        }

    }

    public SceneState CurrentScene
    {
        get { return currentSceneState; }
    }
}
