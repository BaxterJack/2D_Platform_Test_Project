using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
   

    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D rigidbody;
        [SerializeField]
        float speed = 3.0f;
        float jumpSpeed = 25.0f;
        PlayerManager playerManager;
        int maxJumps = 2;
        int currentJumps = 0;
        private void Start()
        {
            playerManager = PlayerManager.Instance;
            rigidbody = GetComponent<Rigidbody2D>();
            currentJumps = 0;
        }

        void FixedUpdate()
        {
            HandleMovement();
        }

        void HandleMovement()
        {
            if (playerManager.CurrentState == PlayerManager.PlayerState.Alive)
            {

                Vector3 velocity = rigidbody.velocity;

                if (Input.GetKey(KeyCode.A))
                {
                    velocity.x = -speed;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    velocity.x = speed;
                }
                rigidbody.velocity = velocity;
            }
        }

        private void Update()
        {
            HandleJump();
        }

        void HandleJump()
        {
            if (playerManager.CurrentState == PlayerManager.PlayerState.Alive)
            {
                Vector3 velocity = rigidbody.velocity;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump(ref velocity);
                }
                rigidbody.velocity = velocity;
            }
        }

        void Jump(ref Vector3 velocity)
        {
            if(currentJumps == maxJumps)
            {
                return;
            }
            currentJumps++;
            velocity.y = jumpSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Ground")
            {
                currentJumps = 0;
            }
        }
    }
}
