using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnG : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public Vector3 centre;
    public Vector3 size;

    public int maxSpawnedItems = 10; // Maximum number of spawned items to keep

    private List<GameObject> spawnedItems = new List<GameObject>(); // List to store spawned items
    private GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager script in the scene

        int numSpawns = gameManager.currentRound; // Get the current round from the GameManager

        for (int i = 0; i < numSpawns; i++)
        {
            SpawnItem();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(centre, size);
    }

    void SpawnItem()
    {
        if (itemPrefabs.Length == 0)
        {
            Debug.LogWarning("No item prefabs assigned!");
            return;
        }

        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject itemPrefab = itemPrefabs[randomIndex];

        // Check if there are inactive spawned items in the pool, reuse them
        for (int i = 0; i < spawnedItems.Count; i++)
        {
            if (!spawnedItems[i].activeInHierarchy)
            {
                spawnedItems[i].transform.position = GetRandomSpawnPosition();
                spawnedItems[i].SetActive(true);
                return;
            }
        }

        // If the maximum number of spawned items is reached, return
        if (spawnedItems.Count >= maxSpawnedItems)
            return;

        // Spawn a new item
        GameObject spawnedItem = Instantiate(itemPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        spawnedItems.Add(spawnedItem);

        gameManager.AddSpawnGItemName(spawnedItem.name);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 position = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        return position;
    }
}
