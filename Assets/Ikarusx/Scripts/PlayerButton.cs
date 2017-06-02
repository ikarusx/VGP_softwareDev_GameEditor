﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerButton : MonoBehaviour
    , IPointerClickHandler
    , IBeginDragHandler
    , IDragHandler
    , IEndDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{

    public GameObject player;

    private GameObject currentObj;
    
	void Start () {
	
	}
	
	void Update () {

    }

    public void OnBeginDrag(PointerEventData ped)
    {
        CreateObject();
    }

    public void OnDrag(PointerEventData ped)
    {
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
        currentObj = GameObject.FindGameObjectWithTag("Player");

        if (!currentObj)
        {
            Vector3 objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            objPos.z = 0;

            currentObj = (GameObject)Instantiate(player, objPos, Quaternion.identity);
        }
    }
}