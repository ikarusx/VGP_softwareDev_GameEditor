using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour
{
    public enum Pattern
    {
        HORIZONTAL,
        VERTICAL
    }
    public Pattern pattern = Pattern.HORIZONTAL;

    public float speed = 4f;
    public float jumpforce = 100f;

    public LayerMask whatIsGround;
    public Transform groundLeft;
    public Transform groundRight;

    public Collider2D weakPoint;

    private const float groundradius = 0.2f;
    private static bool canMove;
    
    private float directionX = 0;
    private float directionY = 0;
    private int counter = 0;

    private Rigidbody2D myRigidBody2D;

    // Use this for initialization
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        canMove = false;
    }

    void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (EditorIk.Instance.currentState == EditorIk.eState.PLAYING)
        {
            if (pattern == Pattern.HORIZONTAL)
            {
                myRigidBody2D.gravityScale = 1;
                directionX = directionX == 0 ? -1 : directionX;
                directionY = 0;

                if (!Physics2D.OverlapCircle(groundLeft.position, groundradius, whatIsGround))
                {
                    directionX = 1;
                }
                else if (!Physics2D.OverlapCircle(groundRight.position, groundradius, whatIsGround))
                {
                    directionX = -1;
                }

                Move();
            }
            else if (pattern == Pattern.VERTICAL)
            {
                myRigidBody2D.gravityScale = 0;
                directionX = 0;
                directionY = directionY == 0 ? -1 : directionY;

                ++counter;

                if (counter >= 30)
                {
                    counter = 0;
                    directionY *= -1;
                }

                Move();
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (EditorIk.Instance.currentState == EditorIk.eState.PLAYING)
        {
            if (collision.tag == "Player")
            {
                if (collision.IsTouching(weakPoint))
                {
                    Destroy(gameObject);
                }
                else
                {
                    GameObject startPoint = GameObject.FindGameObjectWithTag("Start");

                    if (startPoint)
                    {
                        collision.transform.position = startPoint.transform.position;
                    }
                }
            }
        }
    }

    public void ToggleMove()
    {
        canMove = !canMove;
    }

    void Move()
    {
        transform.position += (new Vector3(directionX, directionY)) * Time.deltaTime * speed;
    }
}
