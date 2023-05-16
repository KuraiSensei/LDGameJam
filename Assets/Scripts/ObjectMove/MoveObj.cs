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

        // Convert mouse position to world position with the correct distance
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        item.transform.position = worldPosition;

        // Reset the selected object in the ObjRotation script to null
        ObjRotation objRotation = item.GetComponent<ObjRotation>();
        if (objRotation != null)
        {
            objRotation.selectedObject = null;
        }
    }


}

