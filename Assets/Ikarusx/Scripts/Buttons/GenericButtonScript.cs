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

    public GameObject prefab;

    private GameObject currentObj;

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
    }
}
