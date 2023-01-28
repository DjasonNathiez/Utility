using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool oversizeEffect;
    public float oversizeScale = 2f;
    public float oversizeTransitionDuration = 0.5f;
    private Vector3 normalScale;
    public bool punchEffect;
    public float punchScale = 1.05f;
    public float punchDuration = 0.5f;
    
    private void Awake()
    {
        normalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOKill();
        if (oversizeEffect)
        {
            transform.DOScale(normalScale * oversizeScale, oversizeTransitionDuration).SetEase(Ease.OutBounce);
        }
    }
    

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        if (oversizeEffect)
        {
            transform.DOScale(normalScale, oversizeTransitionDuration);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOKill();
        if (punchEffect)
        {
            transform.DOPunchScale(normalScale * punchScale, punchDuration);
        }
    }
}
