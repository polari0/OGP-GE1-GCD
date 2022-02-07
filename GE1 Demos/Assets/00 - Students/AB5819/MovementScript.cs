using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AB5819
{
    public class MovementScript : MonoBehaviour
    {
        CharacterController controller;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float sprintspeed = 10f;
        [SerializeField] private Vector3 movement;
        [SerializeField] private float jumpSpeed = 8.0F;
        [SerializeField] private float gravity = 15.0F;
        private Vector3 moveDirection = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (controller.isGrounded && Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                float y = Input.GetAxis("Vertical");
                float x = 0;
                movin(x, y);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                float x = Input.GetAxis("Horizontal");
                float y = 0;
                movin(x, y);
            }
            
            void movin(float x, float y)
            {
                Vector3 move = transform.right * x + transform.forward * y;
                move.Normalize();
                movement = transform.right * x + transform.forward * y;
                movement *= speed;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    controller.Move(move * sprintspeed * Time.deltaTime);
                }
                else
                {
                    controller.Move(move * speed * Time.deltaTime);
                }
            }
        }
    } 
}