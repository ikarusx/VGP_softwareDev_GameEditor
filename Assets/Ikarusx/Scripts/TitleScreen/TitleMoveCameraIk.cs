using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleMoveCameraIk : MonoBehaviour
{
    [SerializeField]
    //private GameObject player;

    public float speed = 0.1f;
    public float distance = 25f;

    Vector3 startingPos;

    bool goingRight;

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
        goingRight = true;
    }

    public void FixedUpdate()
    {
        if (transform.position.x >= startingPos.x + distance - 1f)
        {
            goingRight = false;
        }
        if(transform.position.x <= startingPos.x + 1f)
        {
            goingRight = true;
        }

        Move();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Move()
    {
        if (goingRight)
        {
            transform.position = Vector3.Lerp(transform.position, startingPos + new Vector3(distance, 0f, 0f), Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startingPos, Time.deltaTime * speed);
        }
    }
}
