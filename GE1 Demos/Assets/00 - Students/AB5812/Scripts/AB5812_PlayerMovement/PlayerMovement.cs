using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AB5812
{
    public class PlayerMovement : MonoBehaviour
    {
        public PlayerJump jump;
        [SerializeField] float walkSpeed;
        [SerializeField] float airSpeed;
        [SerializeField] float speed;
        Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            jump = FindObjectOfType<PlayerJump>();
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.W) && jump.grounded == true)
            {
                rb.AddForce(transform.forward * speed * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.forward * airSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S) && jump.grounded == true)
            {
                rb.AddForce(-transform.forward * speed * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.forward * airSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D) && jump.grounded == true)
            {
                rb.AddForce(transform.right * speed * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(transform.right * airSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A) && jump.grounded == true)
            {
                rb.AddForce(-transform.right * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right * airSpeed * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (rb.velocity.magnitude > walkSpeed && jump.grounded == true)
            {
                rb.velocity = rb.velocity.normalized * walkSpeed;
            }
        } 
    }
}
