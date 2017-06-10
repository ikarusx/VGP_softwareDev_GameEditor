using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEditor;

public class LoadPrefab : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{

    [SerializeField]
    private GameObject LoadSlot;

    [SerializeField]
    private GameObject SaveSlot;


    void Start()
    {

    }

    //void Load()
    //{
    //    Destroy(level);
    //    GameObject go = Instantiate(Resources.Load("Level",  typeof(GameObject))) as GameObject;
    //    level = go;
    //    SaveScript.level = go;
    //    GameObject newplayer = go.transform.Find("Player").gameObject;

    //    if(newplayer != null)
    //    {
    //        print("Found new player");
    //        CameraScript.player = newplayer;
    //    }
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        SaveSlot.SetActive(false);
        LoadSlot.SetActive(true);
        LoadSlot.transform.GetChild(3).GetComponent<Text>().text = "Choose a load slot";
        object prefab1 = Resources.Load("Slot1");
        object prefab2 = Resources.Load("Slot2");
        object prefab3 = Resources.Load("Slot3");
        LoadSlot.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Slot 1";
        LoadSlot.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Slot 2";
        LoadSlot.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Slot 3";
        if (prefab1 == null)
        {
            LoadSlot.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Empty slot";
        }
        if (prefab2 == null)
        {
            LoadSlot.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Empty slot";
        }
        if (prefab3 == null)
        {
            LoadSlot.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Empty slot";
        }
        print("click load");
        //Load();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
