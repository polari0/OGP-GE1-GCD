using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ObjectSpawner : NetworkBehaviour
{
    [SerializeField]
    GameObject spawnnablObject;

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (IsServer)
        {
            GameObject go = Instantiate(spawnnablObject);
            NetworkObject no = go.GetComponent<NetworkObject>();
            no.Spawn();
        }
    }
}
