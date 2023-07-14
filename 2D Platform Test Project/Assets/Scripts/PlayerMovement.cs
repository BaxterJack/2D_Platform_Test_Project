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
        [SerializeField]
        float jumpSpeed = 15.0f;
        PlayerManager playerManager;
        private void Start()
        {
            playerManager = PlayerManager.Instance;
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
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
                if (Input.GetKey(KeyCode.Space))
                {
                    velocity.y = jumpSpeed;
                }
                rigidbody.velocity = velocity;
            }
        }
    }
}
