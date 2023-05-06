using System.Collections.Generic;
using UnityEngine;

public class CollidingPrefab : MonoBehaviour
{
    public List<GameObject> collidingObjects = new List<GameObject>();
    public GameObject newPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        if (collidingObjects.Count > 0)
        {
            // Change the prefab to the new prefab
            Instantiate(newPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

