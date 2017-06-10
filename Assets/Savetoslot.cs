using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Savetoslot : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public GameObject level;
    public GameObject saveslot;

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
    // Use this for initialization
    void Start () {
	
	}

    void Save()
    {
#if UNITY_EDITOR
        if (saveslot.transform.GetChild(0) == gameObject.transform)
            PrefabUtility.CreatePrefab("Assets/Resources/Slot1.prefab", level);
        else if (saveslot.transform.GetChild(1) == gameObject.transform)
            PrefabUtility.CreatePrefab("Assets/Resources/Slot2.prefab", level);
        else if (saveslot.transform.GetChild(2) == gameObject.transform)
            PrefabUtility.CreatePrefab("Assets/Resources/Slot3.prefab", level);
#endif
        saveslot.SetActive(false);

        //Need to load main menu
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
