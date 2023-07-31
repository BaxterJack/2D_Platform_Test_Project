using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField]
    Canvas introcanvas;
    Canvas thisCanvas;

    private void Start()
    {
        thisCanvas = GetComponentInParent<Canvas>();
    }
    public void StartGame()
    {
        //GameSceneManager.Instance.LoadScene(GameSceneManager.SceneState.Fort);
        thisCanvas.gameObject.SetActive(false);
        introcanvas.gameObject.SetActive(true);
    }
}
