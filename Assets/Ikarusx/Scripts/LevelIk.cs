using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelIk : MonoBehaviour {

    public static HUDScript mHUD;
    public PlayerControllerIk playerController;
    public EndPointScript endPointScript;

    // Use this for initialization
    void Start () {
        if (!mHUD)
        {
            mHUD = transform.FindChild("HUDCanvas").gameObject.GetComponent<HUDScript>();
        }
        if (!playerController)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerIk>();
        }
        if (!endPointScript)
        {
            endPointScript = GameObject.FindGameObjectWithTag("End").GetComponent<EndPointScript>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!mHUD)
        {
            mHUD = transform.FindChild("HUDCanvas").gameObject.GetComponent<HUDScript>();
        }
        if (!playerController)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerIk>();
        }
        if (!endPointScript)
        {
            endPointScript = GameObject.FindGameObjectWithTag("End").GetComponent<EndPointScript>();
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
            mHUD.gameObject.SetActive(true);
            playerController.ToggleMove();
            endPointScript.ToggleEdit();
        }
        else
        {
            mHUD.gameObject.SetActive(false);
            playerController.ToggleMove();
            endPointScript.ToggleEdit();
        }
    }
}
