using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AB0136
{

    public class AB0136MouseLook : MonoBehaviour
    {
        public float mouseSensitivity = 250;
        public Transform playerBody;

        float xRotation = 0f;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // moving camera x-axis
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // moving camera y-axis

            xRotation -= mouseY; //stop rotation errors
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //make sure the camera rotation does not go over 90 degrees

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //keeping track of x-rotation and ^

            playerBody.Rotate(Vector3.up * mouseX);

            //if (Input.GetKeyDown(KeyCode.LeftControl))
            //{
              
            //    transform.position = new Vector3(transform.position.x, 1 / 3, 1/2);

            //}

            //if (Input.GetKeyUp(KeyCode.LeftControl))
            //{
               
            //    transform.position = new Vector3(0, 1, 1/2);

            //}
        }
    }
}
