using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AB5812
{
    public class PlayerJump : MonoBehaviour
    {
        public bool grounded;
        Rigidbody rb;
        [SerializeField] float jumpForce;
        [SerializeField] float boxCastSize;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
        }

        private void FixedUpdate()
        {
            RaycastHit hit;

            if (Physics.BoxCast(center: transform.position, halfExtents: transform.lossyScale / 2, Vector3.down, out hit))
            {
                if (hit.distance <= boxCastSize)
                {
                    grounded = true;
                }
                else
                {
                    grounded = false;
                }
            }
        }

        private void jump()
        {
            if (grounded)
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
    } 
}
