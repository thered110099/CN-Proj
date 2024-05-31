using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // Assign the player prefab in the Inspector
    public Transform[] spawnPoints; // Assign spawn points in the Inspector

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }

    private Transform GetRandomSpawnPoint()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned.");
            return null;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}
