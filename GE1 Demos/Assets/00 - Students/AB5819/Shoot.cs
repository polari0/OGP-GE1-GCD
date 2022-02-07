using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AB5819
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField]private float BulletSpeed = 20;
        [SerializeField] private GameObject bullet;
        Quaternion posUp = Quaternion.Euler(0, 0, 0);
        Quaternion posRight = Quaternion.Euler(0, 90, 0);
        Quaternion posDown = Quaternion.Euler(0, 180, 0);
        Quaternion posLeft = Quaternion.Euler(0, -90, 0);
        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Instantiate(bullet, transform.position, bullet.transform.rotation = posUp);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Instantiate(bullet, transform.position, bullet.transform.rotation = posDown);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Instantiate(bullet, transform.position, bullet.transform.rotation = posRight);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Instantiate(bullet, transform.position, bullet.transform.rotation = posLeft);
            }
        }
    }
}
