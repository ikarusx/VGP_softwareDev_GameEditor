using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartPointScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public static bool isEditting = true;

    private GameObject activePlayer;
    private string parentTag = "Level";

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

    public void ToggleEdit()
    {
        isEditting = !isEditting;
    }

    public void SpawnPlayer()
    {
        activePlayer = GameObject.FindGameObjectWithTag("Player");

        if (!activePlayer)
        {
            Vector3 objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            objPos.z = 0;

            activePlayer = (GameObject)Instantiate(player, objPos, Quaternion.identity);

            GameObject parent = GameObject.FindGameObjectWithTag(parentTag);

            if (parent)
            {
                activePlayer.transform.parent = parent.transform;
            }
        }

        activePlayer.transform.position = transform.position;
    }
}
