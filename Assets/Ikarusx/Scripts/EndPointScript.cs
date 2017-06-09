using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndPointScript : MonoBehaviour
{
    public static bool isEditting = true;

    // Use this for initialization
    void Start()
    {
    }

    public void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (!isEditting)
        {
            Debug.Log("collider tag = " + thing.gameObject.tag);

            if (thing.gameObject.tag != "Player")
                return;
            //if (invoked) return;
            //if (OnCollisionEvent != null)
            //    OnCollisionEvent.Invoke();

            SceneManager.LoadScene("LevelComplete");
        }
    }

    public void ToggleEdit()
    {
        isEditting = !isEditting;
    }
}
