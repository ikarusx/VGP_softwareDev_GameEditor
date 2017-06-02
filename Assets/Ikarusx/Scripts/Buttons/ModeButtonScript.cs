using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ModeButtonScript : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{

    public Text label;
    public GameObject editor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        if (label.text.Equals("Editing Mode"))
        {
            label.text = "Playing Mode";
            gameObject.GetComponentInChildren<Text>().text = "Edit";
            editor.GetComponent<EditorIk>().ChangeState();
        }
        else
        {
            label.text = "Editing Mode";
            gameObject.GetComponentInChildren<Text>().text = "Play";
            editor.GetComponent<EditorIk>().ChangeState();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
