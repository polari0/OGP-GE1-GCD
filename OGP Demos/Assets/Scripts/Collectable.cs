using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent != collision.transform && collision.tag == "Player") 
        {
            transform.parent = collision.transform;
        }
        
    }
}
