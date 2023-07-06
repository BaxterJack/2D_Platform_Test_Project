using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    bool isMoving = false;
    float horizontalMove = 0.0f;

    Vector2 npcPosition;

    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = GameSceneManager.Instance;
    }

    private void Update()
    {
        if (gameSceneManager.CurrentScene == GameSceneManager.SceneState.Fort)
        {
            WalkAnimation();
            FlipSprite();
        }
           
    }
    void WalkAnimation()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        horizontalMove = rigidbody2D.velocity.x;

        isMoving = horizontalMove > 0.1f || horizontalMove < -0.1f;
        animator.SetBool("IsMoving", isMoving);

    }

    void FlipSprite()
    {
        if (IsGoingRight())
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        else if (!IsGoingRight())
        {
            transform.localScale = new Vector3(1, 1, 1);
            
        }
    }

    public bool IsGoingRight()
    {
        Vector2 target = GetComponent<NPC>().waypoint.transform.position;

        if (target.x > npcPosition.x) // Going right
        {
            return true;
        }
        else   //going Left
        {
            return false;
        }
    }
}
