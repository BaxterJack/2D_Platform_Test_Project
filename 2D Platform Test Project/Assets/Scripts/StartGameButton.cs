using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField]
    public Button startGame;


    void Start()
    {
        startGame.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        GameSceneManager.Instance.LoadScene(GameSceneManager.SceneState.DemoLevel);
    }
}
