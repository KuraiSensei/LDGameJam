using UnityEngine;

public class SpawnPrefabOnClick : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject spawnPositionObject;

    public void SpawnPrefab()
    {
        Vector3 spawnPosition = spawnPositionObject.transform.position;
        GameObject newPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        // You can set the rotation of the new prefab by modifying the Quaternion.identity argument above
    }
}
