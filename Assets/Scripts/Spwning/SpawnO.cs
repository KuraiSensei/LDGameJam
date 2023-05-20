using UnityEngine;

public class SpawnO : MonoBehaviour
{
    public bool canSpawn = false;
    public GameObject[] itemPrefabs;
    public Vector3 spawnAreaCenter;
    public Vector3 spawnAreaSize;
    public Color spawnAreaColor = Color.red;

    private int currentItemIndex = 0;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = spawnAreaColor;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }

    private void Update()
    {
        if (canSpawn)
        {
            SpawnItem();
            canSpawn = false;
        }
    }

    private void SpawnItem()
    {
        if (itemPrefabs.Length == 0)
        {
            Debug.LogWarning("No item prefabs assigned!");
            return;
        }

        GameObject itemPrefab = itemPrefabs[currentItemIndex];
        Instantiate(itemPrefab, GetRandomSpawnPosition(), Quaternion.identity);

        gameManager.AddSpawnedItemName(itemPrefab.name);

        currentItemIndex = (currentItemIndex + 1) % itemPrefabs.Length;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 min = spawnAreaCenter - spawnAreaSize * 0.5f;
        Vector3 max = spawnAreaCenter + spawnAreaSize * 0.5f;

        Vector3 spawnPosition = new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z)
        );

        return spawnPosition;
    }
}
