using UnityEngine;
using System.Collections;

public class DragIk : MonoBehaviour
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
        if (EditorIk.Instance.currentState == EditorIk.eState.EDITING)
        {
            Vector3 currentpos = new Vector3(Input.mousePosition.x - posx, Input.mousePosition.y - posy, 0);
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(currentpos);

            worldpos.z = 0;
            transform.position = worldpos;

            EditorIk.Instance.draggedObject = gameObject;
        }
    }

    public void OnMouseUp()
    {
        Invoke("ResetDragged", 0.3f);
    }

    void ResetDragged()
    {
        EditorIk.Instance.draggedObject = null;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
