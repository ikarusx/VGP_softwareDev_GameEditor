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
    public GameObject level;

    void Start()
    {
    }

    void Save()
    {
        PrefabUtility.CreatePrefab("Assets/Resources/Level.prefab", level);
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
