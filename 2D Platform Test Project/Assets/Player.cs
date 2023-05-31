using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {

        //[SerializeField]
        //Animator animator;

        //[SerializeField]
        //LayerMask enemeyLayers;


        //[SerializeField]
        //Transform attackPoint;
        //[SerializeField]
        //float attackRange = 0.3f;
        // float point;

        //[SerializeField]
        //SpriteRenderer spriteRenderer;
        //bool isMoving = false;
        //float horizontalMove = 0.0f;

        void Start()
        {
            // point = attackPoint.localPosition.x;
        }

        void Update()
        {
            //horizontalMove = Input.GetAxisRaw("Horizontal");
            //isMoving = horizontalMove != 0;

            //animator.SetBool("IsMoving", isMoving);

            //if(horizontalMove > 0.0f)
            //{
            //    spriteRenderer.flipX = true;

            //    InvertAttackPosition(-1);

            //}
            //else if (horizontalMove < 0.0f)
            //{
            //    spriteRenderer.flipX = false;
            //    InvertAttackPosition(1);

            //}
            //bool isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName("Stab");
            //isAttacking |= animator.GetCurrentAnimatorStateInfo(0).IsName("Slash");

            //if (Input.GetMouseButtonDown(0) && !isAttacking)
            //{
            //    Stab();
            //}

            //if (Input.GetMouseButtonDown(1) && !isAttacking)
            //{
            //    Slash();
            //}

        }







    }
}