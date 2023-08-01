using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    Animator animator;
    void PlayGame()
    {
        GameSceneManager.Instance.LoadNextLevel(GameSceneManager.SceneState.Fort);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


}
