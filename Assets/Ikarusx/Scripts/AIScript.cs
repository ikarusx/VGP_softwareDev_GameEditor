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
    public float verticalMultiplier = 2f;

    public LayerMask whatIsGround;
    public Transform groundLeft;
    public Transform groundRight;

    public Collider2D weakPoint;

    private const float groundradius = 0.2f;
    private static bool canMove;
    
    private float directionX = 0f;
    private float directionY = 0f;
    private float counter = 0;

    private Rigidbody2D myRigidBody2D;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                Flip();

                Move();
            }
            else if (pattern == Pattern.VERTICAL)
            {
                myRigidBody2D.gravityScale = 0;
                directionX = 0;
                directionY = directionY == 0 ? 1 : directionY;

                ++counter;

                if (counter >= 30f * verticalMultiplier)
                {
                    counter = 0;
                    directionY *= -1;
                }

                Move();
            }
        }
    }

    private void Flip()
    {
        spriteRenderer.flipX = directionX == -1;
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

    public void SetPattern(Pattern pat)
    {
        if (pat == Pattern.HORIZONTAL)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        else if (pat == Pattern.VERTICAL)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        pattern = pat;
    }

    void Move()
    {
        transform.position += (new Vector3(directionX, directionY)) * Time.deltaTime * speed;
    }
}
