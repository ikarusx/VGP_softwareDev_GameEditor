using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DropdownScript : MonoBehaviour {

    public Dropdown dropdown;
    public AIButtonScript aiButtonScript;

    List<string> options = new List<string>() { "Hori", "Vert" };

    public void Dropdown_IndexChanged(int index)
    {
        aiButtonScript.pattern = (AIScript.Pattern)index;
    }

	// Use this for initialization
	void Start ()
    {
        dropdown.AddOptions(options);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void PopulateList()
    {
        dropdown.AddOptions(options);
    }
}
