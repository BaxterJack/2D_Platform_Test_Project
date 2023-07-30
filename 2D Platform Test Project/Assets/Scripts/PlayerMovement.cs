using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
   

    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D rBody;
        [SerializeField]
        float speed = 3.0f;
        float jumpSpeed = 25.0f;
        PlayerManager playerManager;
        public int maxJumps = 2;
        int currentJumps = 0;

        public void BoostSpeed()
        {
            speed += 0.5f;
        }
        private void Start()
        {
            playerManager = PlayerManager.Instance;
            rBody = GetComponent<Rigidbody2D>();
            currentJumps = 0;
        }

        void FixedUpdate()
        {
            HandleMovement();
        }

        void HandleMovement()
        {
            if (TabletManager.Instance.IsTabletCanvasActive)
            {
                return;
            }
            if (playerManager.CurrentState == PlayerManager.PlayerState.Alive)
            {

                Vector3 velocity = rBody.velocity;

                if (Input.GetKey(KeyCode.A))
                {
                    velocity.x = -speed;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    velocity.x = speed;
                }
                rBody.velocity = velocity;
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
                Vector3 velocity = rBody.velocity;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump(ref velocity);
                }
                rBody.velocity = velocity;
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
