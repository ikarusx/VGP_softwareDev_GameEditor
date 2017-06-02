using UnityEngine;
using System.Collections;

public class MoveCameraIk : MonoBehaviour
{
  
    [SerializeField]
    private GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    public void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x = player.transform.position.x + 6;

        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
        //transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
