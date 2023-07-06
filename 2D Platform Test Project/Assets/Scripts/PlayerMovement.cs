using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{


    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField]
        float speed = 3.0f;
        [SerializeField]
        float jumpSpeed = 15.0f;
        PlayerManager playerManager;
        private void Start()
        {
            playerManager = PlayerManager.Instance;
        }

        void FixedUpdate()
        {
            if (playerManager.CurrentState == PlayerManager.PlayerState.Alive)
            {
                Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
                Vector3 velocity = rigidbody2D.velocity;

                if (Input.GetKey(KeyCode.A))
                {
                    velocity.x = -speed;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    velocity.x = speed;
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    velocity.y = jumpSpeed;
                }
                rigidbody2D.velocity = velocity;
            }
        }
    }
}
