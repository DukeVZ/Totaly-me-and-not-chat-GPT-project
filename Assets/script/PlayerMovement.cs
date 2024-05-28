    using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5.0f; // Movement speed
        public float jumpHeight = 2.0f; // Jump height
        public float gravity = -9.81f; // Gravity force

        public CharacterController controller;
        private Vector3 velocity;
        private bool isGrounded;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            // Check if the player is on the ground
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // Get input for movement
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Calculate the movement direction
            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            // Move the player
            controller.Move(move * speed * Time.deltaTime);

            // Jumping logic
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Apply gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
    


