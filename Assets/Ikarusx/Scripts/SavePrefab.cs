using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEditor;

public class SavePrefab : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    [SerializeField]
    private GameObject SaveSlot;
    void Start()
    {
    }

    void Save()
    {
        SaveSlot.SetActive(true);
        SaveSlot.transform.GetChild(3).GetComponent<Text>().text = "Choose a save slot";
        object prefab1 = Resources.Load("Slot1");
        object prefab2 = Resources.Load("Slot2");
        object prefab3 = Resources.Load("Slot3");
        SaveSlot.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Slot 1";
        SaveSlot.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Slot 2";
        SaveSlot.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Slot 3";
        if (prefab1 == null)
        {
            SaveSlot.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Empty slot";
        }
        if (prefab2 == null)
        {
            SaveSlot.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Empty slot";
        }
        if (prefab3 == null)
        {
            SaveSlot.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Empty slot";
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("click save");
        Save();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
