using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject trapPrefab;
    public int numberOfTraps = 10;
    public Vector3 spawnAreaSize = new Vector3(10f, 1f, 10f);

    void Start()
    {
        SpawnTraps();
    }

    void SpawnTraps()
    {
        for (int i = 0; i < numberOfTraps; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            GameObject trap = Instantiate(trapPrefab, randomPosition, randomRotation);
            if (trap == null)
            {
                Debug.LogError("Trap prefab is not assigned!");
                return;
            }

            Debug.Log($"Trap {i + 1} spawned at position: {randomPosition}");
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            Random.Range(0f, spawnAreaSize.y),
            Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
        );

        return transform.position + randomPosition;
    }
}
