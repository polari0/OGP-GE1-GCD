using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
    }

    private void OnServerStarted()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                GameObject go = Instantiate(playerPrefab);
                NetworkObject no = go.GetComponent<NetworkObject>();
                no.SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
            }

            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectCallback;
        }
    }

    private void OnClientConnectCallback(ulong clientID)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            GameObject go = Instantiate(playerPrefab);
            NetworkObject no = go.GetComponent<NetworkObject>();
            no.SpawnAsPlayerObject(clientID);
        }
    }

}
