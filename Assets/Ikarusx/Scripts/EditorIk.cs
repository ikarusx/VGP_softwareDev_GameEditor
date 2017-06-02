using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EditorIk : MonoBehaviour {

    public LevelIk mLevelPrefab;

    public GameObject platformButton;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.currentSelectedGameObject == platformButton)
        //        Debug.Log("left-click over a GUI element!");

        //    else Debug.Log("just a left-click!");
        //}
    }

    public void ClickPlatform()
    {
        //print("lol");
    }

    void createLevel()
    {
        // creating new template level object from mLevelPrefab
    }
}
