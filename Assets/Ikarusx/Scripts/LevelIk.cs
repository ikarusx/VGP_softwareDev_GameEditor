using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelIk : MonoBehaviour {

    public static HUDScript mHUD;
    public PlayerControllerIk playerController;

    // Use this for initialization
    void Start () {
	    if (!playerController)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerIk>();
        }
        if (!mHUD)
        {
            mHUD = transform.FindChild("HUDCanvas").gameObject.GetComponent<HUDScript>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!playerController)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerIk>();
        }
        if (!mHUD)
        {
            mHUD = transform.FindChild("HUDCanvas").gameObject.GetComponent<HUDScript>();
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
            playerController.ToggleMove();
            mHUD.gameObject.SetActive(true);
        }
        else
        {
            playerController.ToggleMove();
            mHUD.gameObject.SetActive(false);
        }
    }
}
