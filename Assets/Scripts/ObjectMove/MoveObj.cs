using UnityEngine;

public class MoveObj : MonoBehaviour
{
   /* private bool isDragging = false;
    private Vector3 startPosition;
    private float distance;

    public GameObject item;
    public GameObject tempParent;

    // Use this for initialization
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            item.transform.position = rayPoint;
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        distance = Vector3.Distance(item.transform.position, Camera.main.transform.position);
        startPosition = item.transform.position;

        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;

        item.transform.parent = tempParent.transform;
    }

    void OnMouseUp()
    {
        isDragging = false;

        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;

        item.transform.parent = null;
        item.transform.position = startPosition;
    }
   */
   
    private bool isDragging = false;
    private Vector3 startPosition;
    private float distance;

    public GameObject item;
    private GameObject tempParent;

    void Start()
    {
        // Find the tempParent GameObject by name in the scene
        tempParent = GameObject.Find("RefPoint");

        if (tempParent == null)
        {
            Debug.LogError("TempParent (RefPoint) not found in the scene!");
        }
        else
        {
            item.GetComponent<Rigidbody>().useGravity = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                item.transform.position = hit.point;
            }
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        distance = Vector3.Distance(item.transform.position, Camera.main.transform.position);
        startPosition = item.transform.position;

        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;

        item.transform.parent = tempParent.transform;

        // Set the selected object in the ObjRotation script to this object
        ObjRotation objRotation = item.GetComponent<ObjRotation>();
        if (objRotation != null)
        {
            objRotation.selectedObject = item;
        }
    }


    void OnMouseUp()
    {
        isDragging = false;

        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;

        item.transform.parent = null;

        // Raycast to check for collisions along the ray between the camera and the item
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        // Find the closest valid hit point to drop the item
        float closestDistance = Mathf.Infinity;
        Vector3 dropPosition = Vector3.zero;

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            // Check if the hit object is a valid drop target (you can customize this condition based on your game logic)
            if (hit.collider.CompareTag("DropTarget"))
            {
                float distance = Vector3.Distance(item.transform.position, hit.point);

                // Update the closest hit point if it's closer than the current closest distance
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    dropPosition = hit.point;
                }
            }
        }

        // Set the drop position if a valid drop target was found
        if (closestDistance < Mathf.Infinity)
        {
            item.transform.position = dropPosition;
        }

        // Reset the selected object in the ObjRotation script to null
        ObjRotation objRotation = item.GetComponent<ObjRotation>();
        if (objRotation != null)
        {
            objRotation.selectedObject = null;
        }
    }




}

