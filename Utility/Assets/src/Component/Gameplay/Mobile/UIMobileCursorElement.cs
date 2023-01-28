using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIMobileCursorElement : MonoBehaviour,IDragHandler, IEndDragHandler
{
    //REFERENCES
    private RectTransform rect;
    private Vector2 anchoredPosition;
    private bool isTouched;
    
    [Header("Visual")] [Space]
    [SerializeField] private Transform graphicTarget;
    
    [Header("Cursor Settings")] [Space]
    [SerializeField] private float dragThreshold = 0.6f;
    [SerializeField] private float dragOffSetDistance = 30f;
    [SerializeField] private float dragMovementDistance = 100f;

    //public event Action<Vector2> OnMove;
    [Header("Callbacks")] [Space]
    public UnityEvent<Vector2> onMove;

    private void Awake()
    {
        if (graphicTarget == null)
        {
            if (transform.childCount <= 0)
            {
                Logs.Log("UI Mobile Cursor Element", "Graphic target is missing on '" + gameObject.name + "' Mobile Cursor Elements.", LogType.Error, Logs.LogColor.Yellow, Logs.LogColor.Red);
            }
            else
            {
                graphicTarget = transform.GetChild(0);
            }
        }

        if (graphicTarget)
        {
            rect = (RectTransform) graphicTarget;
            anchoredPosition = rect.anchoredPosition;
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        isTouched = true;
        Vector2 offset; 
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, eventData.position, null, out offset);
        
        offset = Vector2.ClampMagnitude(offset, dragOffSetDistance) / dragOffSetDistance;
        rect.anchoredPosition = offset * dragMovementDistance;
        
        Vector2 inputVector = CalculateMovementInput(offset);
        onMove?.Invoke(inputVector);
    }
    private Vector2 CalculateMovementInput(Vector2 offset)
    {
        float x = Mathf.Abs(offset.x) > dragThreshold ? offset.x : 0;
        float y = Mathf.Abs(offset.y) > dragThreshold ? offset.x : 0;
        return new Vector2(x, y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isTouched = false;
        Logs.Log("UI Mobile Cursor Element", "Drag ended", LogType.Log, Logs.LogColor.Yellow, Logs.LogColor.None);
        rect.anchoredPosition = Vector2.zero;
        onMove?.Invoke(Vector2.zero);    
    }

#if UNITY_EDITOR
    
    
    
#endif
}
