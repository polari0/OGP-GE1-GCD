using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AB5823
{
    public class CharacterController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime);
        }
    }

}