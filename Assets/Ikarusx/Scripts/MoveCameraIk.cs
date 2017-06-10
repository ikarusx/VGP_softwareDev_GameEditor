using UnityEngine;
using System.Collections;

public class MoveCameraIk : MonoBehaviour
{
    public GameObject player;

    public float speed = 4f;
    public bool isPlaying;

    // Use this for initialization
    void Start()
    {
        isPlaying = false;
    }

    public void FixedUpdate()
    {
        if (isPlaying)
        {
            Vector3 position = transform.position;
            position.x = player.transform.position.x;// + 6;

            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
            //transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            Move();
        }
    }

    void Move()
    {
        float horiz = Input.GetAxisRaw("Horizontal");

        transform.position += (new Vector3(horiz, 0)) * Time.deltaTime * speed;
    }
}
