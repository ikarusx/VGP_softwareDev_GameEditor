using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EditorScript : MonoBehaviour {

    public GameObject canvas;
    public GameObject platform;

    private GameObject platformParent;

    // Use this for initialization
    void Start ()
    {
        platformParent = GameObject.Find("Platforms");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject == canvas.transform.GetChild(1).gameObject)
            {
                Debug.Log("lol");
                GameObject newPlatform = (GameObject)Instantiate(platform, Vector3.zero, Quaternion.identity);

                newPlatform.transform.parent = platformParent.transform;
            }
        }
	}
}
