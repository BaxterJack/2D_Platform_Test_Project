using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : /*Singleton<GameSceneManager>*/ SingletonDestroy<GameSceneManager>
{
    SceneState currentSceneState;
    Animator sceneFade;
    [SerializeField] float transitionTime = 1f;
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
        sceneFade = GetComponentInChildren<Animator>();
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

    void LoadScene(SceneState sceneName)
    {
        currentSceneState = sceneName;
        string sceneNameString = sceneName.ToString();
        SceneManager.LoadScene(sceneNameString);
        //ChangeThemeMusic(sceneName);
    }

    public void LoadNextLevel(SceneState sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(SceneState sceneName)
    {
        sceneFade.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        LoadScene(sceneName);
    }

    void ChangeThemeMusic(SceneState sceneName)
    {
        AudioManager audioManager = AudioManager.Instance;
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
