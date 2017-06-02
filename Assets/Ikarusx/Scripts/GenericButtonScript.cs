﻿using UnityEngine;
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
    }

    public void OnDrag(PointerEventData ped)
    {
        //print("Dragging");
        currentObj.GetComponent<DragIk>().OnMouseDrag();
    }

    public void OnEndDrag(PointerEventData ped)
    {
        //print("Drag ends");
    }

    public void OnPointerClick(PointerEventData eventData) // 3
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
