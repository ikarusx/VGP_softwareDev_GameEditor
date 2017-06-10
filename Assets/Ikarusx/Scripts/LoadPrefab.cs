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
    public GameObject SaveFunction;
    public GameObject CameraFunction;
    public GameObject level;

    private SavePrefab SaveScript;
    private MoveCameraIk CameraScript;

    void Awake()
    {
        SaveScript = SaveFunction.GetComponent<SavePrefab>();
        CameraScript = CameraFunction.GetComponent<MoveCameraIk>();
    }

    void Start()
    {

    }

    void Load()
    {
        Destroy(level);
        GameObject go = Instantiate(Resources.Load("Level",  typeof(GameObject))) as GameObject;
        level = go;
        SaveScript.level = go;
        GameObject newplayer = go.transform.Find("Player").gameObject;

        if(newplayer != null)
        {
            print("Found new player");
            CameraScript.player = newplayer;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("click load");
        Load();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
