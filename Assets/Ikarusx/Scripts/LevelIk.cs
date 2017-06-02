using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelIk : MonoBehaviour {

    public HUDScript mHUD;
    public PlayerControllerIk playerController;

    // Use this for initialization
    void Start () {
	    if (!playerController)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerIk>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!playerController)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerIk>();
        }
    }

    public void DrawHUD(float timer)
    {
        mHUD.timer = timer;
    }

    public void TogglePlay(bool play)
    {
        if (play)
        {
            playerController.toggleMove();
            mHUD.gameObject.SetActive(true);
            print(mHUD.gameObject.name);
            print(mHUD.gameObject.activeInHierarchy);
            print(mHUD.gameObject.activeSelf);
        }
        else
        {
            playerController.toggleMove();
            mHUD.gameObject.SetActive(false);
            print(mHUD.gameObject.name);
            print(mHUD.gameObject.activeInHierarchy);
            print(mHUD.gameObject.activeSelf);
        }
    }
}
