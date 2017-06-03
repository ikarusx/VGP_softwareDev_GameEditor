using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KillZoneScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
