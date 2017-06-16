using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GarbagePointerScript : MonoBehaviour
    , IPointerClickHandler
    , IBeginDragHandler
    , IDragHandler
    , IEndDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    [SerializeField]
    private Image garbageIcon;
    public float growthSpeed = 3f;

    bool grow = true;
    Vector3 originalScale;

    // Use this for initialization
    void Start()
    {
        originalScale = garbageIcon.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {
            print(EventSystem.current.currentSelectedGameObject.name);
            if (EditorIk.Instance.draggedObject)
            {
                grow = true;
            }
        }
        else
        {
            grow = false;
        }

        if (Input.GetMouseButtonUp(0) && EventSystem.current.IsPointerOverGameObject())
        {
            print(EditorIk.Instance.draggedObject);
            if (EditorIk.Instance.draggedObject)
            {
                Destroy(EditorIk.Instance.draggedObject);
                EditorIk.Instance.draggedObject = null;
            }
        }
    }

    void FixedUpdate()
    {
        if (grow)
        {
            garbageIcon.transform.localScale = Vector3.Lerp(garbageIcon.transform.localScale, originalScale * 1.5f, Time.deltaTime * growthSpeed);
        }
        else if (garbageIcon.transform.localScale.x > originalScale.x)
        {
            garbageIcon.transform.localScale = Vector3.Lerp(garbageIcon.transform.localScale, originalScale, Time.deltaTime * growthSpeed);
        }
    }

    public void OnBeginDrag(PointerEventData ped)
    {
    }

    public void OnDrag(PointerEventData ped)
    {
    }

    public void OnEndDrag(PointerEventData ped)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        grow = false;
    }
}
