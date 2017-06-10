using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class Loadtoslot : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{

    public GameObject SaveFunction1;
    public GameObject SaveFunction2;
    public GameObject SaveFunction3;
    public GameObject LoadFunction1;
    public GameObject LoadFunction2;
    public GameObject CameraFunction;

    public GameObject level;
    public GameObject loadslot;

    private Savetoslot SaveScript1;
    private Savetoslot SaveScript2;
    private Savetoslot SaveScript3;

    private Loadtoslot LoadScript1;
    private Loadtoslot LoadScript2;

    private MoveCameraIk CameraScript;

    void Awake()
    {
        SaveScript1 = SaveFunction1.GetComponent<Savetoslot>();
        SaveScript2 = SaveFunction2.GetComponent<Savetoslot>();
        SaveScript3 = SaveFunction3.GetComponent<Savetoslot>();

        LoadScript1 = LoadFunction1.GetComponent<Loadtoslot>();
        LoadScript2 = LoadFunction2.GetComponent<Loadtoslot>();

        CameraScript = CameraFunction.GetComponent<MoveCameraIk>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("click load");
        Load();
    }
    void Load()
    {
        GameObject go = null;

        object prefab1 = Resources.Load("Slot1");
        object prefab2 = Resources.Load("Slot2");
        object prefab3 = Resources.Load("Slot3");

        if (loadslot.transform.GetChild(0) == gameObject.transform && prefab1 == null)
            return;
        else if (loadslot.transform.GetChild(1) == gameObject.transform && prefab2 == null)
            return;
        else if (loadslot.transform.GetChild(2) == gameObject.transform && prefab3 == null)
            return;

        if (loadslot.transform.GetChild(0) == gameObject.transform)
            go = Instantiate(Resources.Load("Slot1", typeof(GameObject))) as GameObject;
        else if (loadslot.transform.GetChild(1) == gameObject.transform)
            go = Instantiate(Resources.Load("Slot2", typeof(GameObject))) as GameObject;
        else if (loadslot.transform.GetChild(2) == gameObject.transform)
            go = Instantiate(Resources.Load("Slot3", typeof(GameObject))) as GameObject;

        

        Destroy(level);
        //GameObject go = Instantiate(Resources.Load("Level", typeof(GameObject))) as GameObject;
        level = go;
        //depends on button
        SaveScript1.level = go;
        SaveScript2.level = go;
        SaveScript3.level = go;

        LoadScript1.level = go;
        LoadScript2.level = go;

        GameObject newplayer = go.transform.Find("Player").gameObject;

        if (newplayer != null)
        {
            print("Found new player");
            CameraScript.player = newplayer;
        }

        loadslot.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
}
