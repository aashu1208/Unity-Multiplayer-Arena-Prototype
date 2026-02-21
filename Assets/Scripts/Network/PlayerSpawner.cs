using UnityEngine;
using Fusion;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;
    [SerializeField]
    private string playerAddress = "Assets/Prefabs/Player.prefab";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            //Runner.Spawn(playerPrefab, Vector3.zero, Quaternion.identity, player);
            LoadAndSpawnPlayer(player);
        }
    }

    private async void LoadAndSpawnPlayer(PlayerRef player)
    {

        AsyncOperationHandle<GameObject> handle = 
        Addressables.LoadAssetAsync<GameObject>(playerAddress);

        await handle.Task;

        if(handle.Status == AsyncOperationStatus.Succeeded)
        {

            Runner.Spawn(handle.Result, Vector3.zero, Quaternion.identity, player);
            Debug.Log("Player Spawned from Addressables successfully!");

        }

        else
        {

            Debug.LogError("Failed to load player prefab from Addressables: "+
            handle.OperationException);
        }
    }
}
