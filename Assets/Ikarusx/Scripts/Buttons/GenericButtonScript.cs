using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GenericButtonScript : MonoBehaviour
    , IPointerClickHandler
    , IBeginDragHandler
    , IDragHandler
    , IEndDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public enum TYPES : int
    {
        Platform = 0,
        AI = 1
    }

    public GameObject prefab;
    public TYPES type;

    private GameObject currentObj;
    private string[] names = new []{ "PlatformContainer", "AIContainer" };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnBeginDrag(PointerEventData ped)
    {
        CreateObject();

        if (currentObj.GetComponent<Rigidbody2D>())
        {
            currentObj.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (currentObj.GetComponent<BoxCollider2D>())
        {
            currentObj.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (currentObj.GetComponent<CircleCollider2D>())
        {
            currentObj.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    public void OnDrag(PointerEventData ped)
    {
        //print("Dragging");
        currentObj.GetComponent<DragIk>().OnMouseDrag();
    }

    public void OnEndDrag(PointerEventData ped)
    {
        //print("Drag ends");
        if (currentObj.GetComponent<Rigidbody2D>())
        {
            currentObj.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (currentObj.GetComponent<BoxCollider2D>())
        {
            currentObj.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (currentObj.GetComponent<CircleCollider2D>())
        {
            currentObj.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CreateObject();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    void CreateObject()
    {
        Vector3 objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        objPos.z = 0;

        currentObj = (GameObject)Instantiate(prefab, objPos, Quaternion.identity);

        GameObject parent = GameObject.Find(names[(int)type]);

        if (parent)
        {
            currentObj.transform.parent = parent.transform;
        }
    }
}
