using UnityEngine;
using System.Collections;


[System.Serializable]
public abstract class EndEvent : MonoBehaviour
{
    public abstract void Invoke();
}


public class EndpointEventHandler : MonoBehaviour
{
    [SerializeField]
    private EndEvent OnCollisionEvent;
    // Use this for initialization
    private bool invoked = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("I'm being updated");
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        Debug.Log("collider tag = " + thing.gameObject.tag);
        if (thing.gameObject.tag != "Player") return;
        if (invoked) return;
        if (OnCollisionEvent != null)
            OnCollisionEvent.Invoke();
    }
}
