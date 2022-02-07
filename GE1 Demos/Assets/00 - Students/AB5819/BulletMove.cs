using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AB5819
{
    public class BulletMove : MonoBehaviour
    {
        [SerializeField] private float movingSpeed = 10;
        
        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movingSpeed);
            transform.Translate(Vector3.down *Time.deltaTime/1.3f);
        }
    }
}