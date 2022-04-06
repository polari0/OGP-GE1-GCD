using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

// Example script for manually spawning the player when a client connects to the online session
// Remember to remove the player prefab from the Network Manager component in the scene if you use this script
public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField] GameObject playerPrefab; // The prefab that we spawn to represent the player

    // Start is called before the first frame update
    void Start()
    {
        // Run the OnServerStarted() method when the server starts
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
    }

    private void OnServerStarted()
    {
        // Only server is allowed to spawn objects into the online session
        if (NetworkManager.Singleton.IsServer)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("GameScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
            // If we started as a host, we also have to spawn a player object for the host
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.SceneManager.OnLoadComplete += OnLoadComplete;

            }
            // Run the OnClientConnectCallback() method each time a client connects the online session. This event is run on the server and on the client that connects
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
        }
    }

    private void OnLoadComplete(ulong clientId, string sceneName, UnityEngine.SceneManagement.LoadSceneMode loadSceneMode)
    {
        if (NetworkManager.Singleton.IsHost && clientId == NetworkManager.Singleton.LocalClientId && sceneName == "GameScene")
        {
            GameObject go = Instantiate(playerPrefab); // Instantiate the player prefab locally on the server
            NetworkObject no = go.GetComponent<NetworkObject>(); // Get a reference to the instantiated objects NetworkObject component 
            no.SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId); // Spawn the object into the online session as the player object of the local player (host)
        }
    }

    // Spawns a player object for the client whose ID is 
    private void OnClientConnectedCallback(ulong clientId)
    {
        // Only the server is allowed to spawn objects into the online session
        if (NetworkManager.Singleton.IsServer /*&& clientId == NetworkManager.Singleton.LocalClientId && sceneName == "GameScene"*/)
        {
            GameObject go = Instantiate(playerPrefab); // Instantiate the player prefab locally on the server
            NetworkObject no = go.GetComponent<NetworkObject>(); // Get a reference to the instantiated objects NetworkObject component 
            no.SpawnAsPlayerObject(clientId); // Spawn the object into the online session as the player object of the client that just connected
        }
    }
}
