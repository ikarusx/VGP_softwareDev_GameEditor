using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class StartPointButtonScript : MonoBehaviour
    , IPointerClickHandler
    , IBeginDragHandler
    , IDragHandler
    , IEndDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{

    public GameObject player;

    private GameObject currentObj;
    private string parentTag = "Level";
    
	void Start () {
	
	}
	
	void Update () {

    }

    public void OnBeginDrag(PointerEventData ped)
    {
        CreateObject();
        currentObj.GetComponent<Rigidbody2D>().gravityScale = 0;
        currentObj.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void OnDrag(PointerEventData ped)
    {
        currentObj.GetComponent<DragIk>().OnMouseDrag();
    }

    public void OnEndDrag(PointerEventData ped)
    {
        //print("Drag ends");
        currentObj.GetComponent<Rigidbody2D>().gravityScale = 1;
        currentObj.GetComponent<CircleCollider2D>().enabled = true;
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
        currentObj = GameObject.FindGameObjectWithTag("Start");

        if (!currentObj)
        {
            Vector3 objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            objPos.z = 0;

            currentObj = (GameObject)Instantiate(player, objPos, Quaternion.identity);

            GameObject parent = GameObject.FindGameObjectWithTag(parentTag);

            if (parent)
            {
                currentObj.transform.parent = parent.transform;
            }
        }
    }
}
