using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(bullet, 2.2f);
    }
    
}
