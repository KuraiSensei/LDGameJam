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
        item.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));

        // Reset the selected object in the ObjRotation script to null
        ObjRotation objRotation = item.GetComponent<ObjRotation>();
        if (objRotation != null)
        {
            objRotation.selectedObject = null;
        }
    }

}

