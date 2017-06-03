using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EditorIk : MonoBehaviour {

    public static EditorIk Instance;

    public enum eState
    {
        EDITING,
        PLAYING
    }

    public LevelIk mLevelPrefab;
    public MoveCameraIk moveCamera;

    public GameObject platformButton;
    public GameObject editorCanvas;

    public float timer = 120f;

    public eState currentState;

    // Use this for initialization
    void Start ()
    {
        Instance = this;
        currentState = eState.EDITING;
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

    public void ChangeState()
    {
        if (currentState == eState.EDITING)
        {
            currentState = eState.PLAYING;

            moveCamera.isPlaying = true;
            editorCanvas.SetActive(false);
            mLevelPrefab.TogglePlay(true);
        }
        else
        {
            currentState = eState.EDITING;

            moveCamera.isPlaying = false;
            editorCanvas.SetActive(true);
            mLevelPrefab.TogglePlay(false);
        }
    }

    public void StartLevel()
    {
        mLevelPrefab.DrawHUD(timer);
    }

    void createLevel()
    {
        // creating new template level object from mLevelPrefab
    }
}
