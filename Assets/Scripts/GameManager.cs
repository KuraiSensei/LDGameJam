using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentRound = 1;
    public SpawnO spawnO;
    public string[] spawnGItemNames;
    public string[] spawnOItemNames;

    private void Start()
    {
        if (currentRound >= 2)
        {
            spawnO.canSpawn = true;
        }
    }

    public void AddSpawnedItemName(string itemName)
    {
        string[] newSpawnOItemNames = new string[spawnOItemNames.Length + 1];
        spawnOItemNames.CopyTo(newSpawnOItemNames, 0);
        newSpawnOItemNames[newSpawnOItemNames.Length - 1] = itemName;
        spawnOItemNames = newSpawnOItemNames;
    }

    public void AddSpawnGItemName(string itemName)
    {
        string[] newSpawnGItemNames = new string[spawnGItemNames.Length + 1];
        spawnGItemNames.CopyTo(newSpawnGItemNames, 0);
        newSpawnGItemNames[newSpawnGItemNames.Length - 1] = itemName;
        spawnGItemNames = newSpawnGItemNames;
    }

}
