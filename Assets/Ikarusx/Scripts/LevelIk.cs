using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelIk : MonoBehaviour {

    public HUDScript mHUD;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TogglePlay(bool play)
    {
        if (play)
        {
            mHUD.gameObject.SetActive(true);
        }
        else
        {
            mHUD.gameObject.SetActive(false);
            print(mHUD.gameObject.activeInHierarchy);
            print(mHUD.gameObject.activeSelf);
        }
    }
}
