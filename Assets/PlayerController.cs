using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Vector3 distance;
    float posx;
    float posy;


    public void OnMouseDown()
    {
        distance = Camera.main.WorldToScreenPoint(transform.position);
        posx = Input.mousePosition.x - distance.x;
        posy = Input.mousePosition.y - distance.y;

    }

    public void OnMouseDrag()
    {
        Vector3 currentpos = new Vector3(Input.mousePosition.x - posx, Input.mousePosition.y - posy, 0);
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(currentpos);
        worldpos.z = 0;
        transform.position = worldpos;
    }

    public float speed = 4f;
    public float jumpforce = 100f;
    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {


        float horiz = Input.GetAxisRaw("Horizontal");

        transform.position += ((new Vector3(horiz, 0))) * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * jumpforce * 3);
        }

    }
}
