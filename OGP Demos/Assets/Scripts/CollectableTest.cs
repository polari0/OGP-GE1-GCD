using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CollectableTest : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsServer && transform.parent != collision.transform && collision.tag == "Player")
        {
            transform.parent = collision.transform;
        }
    }
}
