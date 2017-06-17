using UnityEngine;
using System.Collections;

public class PlayerControllerIk : MonoBehaviour
{
    public float speed = 4f;
    public float jumpforce = 100f;

    public LayerMask whatIsGround;
    public Transform groundcheck;

    private static bool grounded = false;
    private const float groundradius = 0.2f;
    private static bool canMove;
    private bool movingRight = true;

    private Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();    

        grounded = false;
        canMove = false;
    }

    void Update()
    {
        if (!groundcheck)
        {
            groundcheck = transform.GetChild(0);
        }
        if (canMove)
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector3(speed, 0) * horiz);
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * jumpforce * 3);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundradius, whatIsGround);

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

        if (horiz == 0)
        {
            myAnimator.SetBool("isWalking", false);
        }
        else
        {
            myAnimator.SetBool("isWalking", true);
        }

        if ((movingRight && horiz < 0) ||
            (!movingRight && horiz > 0))
        {
            movingRight = !movingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
