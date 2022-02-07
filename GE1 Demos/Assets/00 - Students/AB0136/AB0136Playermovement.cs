using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AB0136
{

    public class AB0136Playermovement : MonoBehaviour
    {

        public CharacterController controller;



        public float speed = 12f;

        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
      public Transform camerahere;
       public int standing = 1/2;
        public GameObject hands;
        
      //  public int crouching = -1 / 2;

        Vector3 velocity;
       public bool isGrounded;


        private void Start()
        {
            //camerahere.transform.position = new Vector3(0, 1 / 2, 1 / 2);
        }

        // Update is called once per frame
        void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime); //framerate independent

            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -1 * gravity);


            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = speed + 6;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = speed - 6;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                //GetComponent<CapsuleCollider>().height = 1;
                // GetComponent<CapsuleCollider>().direction = crouching;
                transform.localScale = new Vector3(1, 0.5f, 1);
                hands.transform.localScale = new Vector3(1, 2, 1);
               camerahere.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);

            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                //GetComponent<CapsuleCollider>().height = 2;
                //GetComponent<CapsuleCollider>().direction = standing;
                camerahere.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
                transform.localScale = new Vector3(1, 1, 1);
                hands.transform.localScale = new Vector3(1, 1, 1);
            }


            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
