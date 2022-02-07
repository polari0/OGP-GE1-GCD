using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AB5823
{
    public class Box : MonoBehaviour
    {
        int bounceNumber = 0;
        Rigidbody boxRB;

        // Start is called before the first frame update
        void Start()
        {
            boxRB = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            bounceNumber++;
            if (bounceNumber > 3)
            {
                boxRB.isKinematic = false;
            }
        }
    } 
}
