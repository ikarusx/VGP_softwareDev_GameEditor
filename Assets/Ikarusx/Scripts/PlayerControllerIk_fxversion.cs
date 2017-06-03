using UnityEngine;
using System.Collections;

public class PlayerControllerIk_fxversion : MonoBehaviour
{
    public float speed = 4f;
    public float jumpforce = 100f;

    // Added by Frank Xu
    public LayerMask whatIsGround;
    public Transform groundcheck;
    

    private static bool grounded = false;
    private const float groundradius = 0.2f;
    private static bool canMove;
    //

    // Use this for initialization
    void Start()
    {
        canMove = false;
    }

    void Update()
    {
        if (canMove)
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector3(speed, 0) * horiz);
            // ikarusx version: 
            /*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * jumpforce * 3);
            }
            */
            // frankx version:
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * jumpforce * 3);
            }
            //
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // frank's version:
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundradius, whatIsGround);
        //
        if (canMove)
        {
            Move();
        }
    }

    public void ToggleMove()
    {
        canMove = !canMove;
    }

    void Move()
    {
        float horiz = Input.GetAxisRaw("Horizontal");

        transform.position += (new Vector3(horiz, 0)) * Time.deltaTime * speed;
    }
}
