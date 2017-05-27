using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


    public float speed = 4f;
    public float jumpforce = 100f;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        //GetComponent<Rigidbody2D>().AddForce(new Vector3(speed, 0) * horiz);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * jumpforce * 3);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxisRaw("Horizontal");

        transform.position += (new Vector3(horiz, 0)) * Time.deltaTime * speed;
    }
}
