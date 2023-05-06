/*using System.Collections.Generic;
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
*/
/*using System.Collections.Generic;
using UnityEngine;

public class CollidingPrefab : MonoBehaviour
{
    public List<GameObject> collidingObjects = new List<GameObject>();
    public GameObject newPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box(Clone)" && !collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Box(Clone)" && collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        if (collidingObjects.Count > 0)
        {
            gameObject.SetActive(false);
            Instantiate(newPrefab, transform.position, transform.rotation);
        }
    }
}
*/
using System.Collections.Generic;
using UnityEngine;

public class CollidingPrefab : MonoBehaviour
{
    public List<GameObject> collidingObjects = new List<GameObject>();
    public GameObject newPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box(Clone)" && !collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Box(Clone)" && collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        if (collidingObjects.Count > 0)
        {
            // Deactivate all objects in collidingObjects list
            foreach (GameObject obj in collidingObjects)
            {
                if (obj.activeSelf)
                {
                    obj.SetActive(false);
                }
            }

            // Instantiate newPrefab at the location of the first object in collidingObjects list
            Instantiate(newPrefab, collidingObjects[0].transform.position, collidingObjects[0].transform.rotation);

            // Clear collidingObjects list
            collidingObjects.Clear();
        }
    }
}
