using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ObjectSpawner : NetworkBehaviour
{
    [SerializeField]
    GameObject spawnnablObject;

    private void Start()
    {
        if (IsServer)
        {
            GameObject go = Instantiate(spawnnablObject, Vector3.zero, Quaternion.identity);
            NetworkObject no = go.GetComponent<NetworkObject>();
            no.Spawn();
        }
    }
    //public override void OnNetworkSpawn()
    //{
    //    if (IsServer)
    //    {
    //        SpawnObject();
    //    }
    //}

    //private void SpawnObject()
    //{
    //    if (IsServer)
    //    {
    //        GameObject go = Instantiate(spawnnablObject);
    //        NetworkObject no = go.GetComponent<NetworkObject>();
    //        no.Spawn();
    //    }
    //}
}
