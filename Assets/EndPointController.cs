using UnityEngine;
using System.Collections;

public class EndPointController : MonoBehaviour {

    private bool invoked = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D thing)
    {
        Debug.Log("collider tag = " + thing.gameObject.tag);
        if (thing.gameObject.tag != "Player") return;
        if (invoked) return;

        invoked = true;
        // Unity 5.3.5 only uses NET 4, so OnCollisionEvent?.Invoke() is invalid.
        OnEnding();
    }

    void OnEnding()
    {
        Debug.Log("Level complete!");
    }
}
