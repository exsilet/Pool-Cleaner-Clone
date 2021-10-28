using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent (typeof (CanvasGroup))]
public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Image _iconImage;

    private CanvasGroup _canvasGroup;
    private Transform _draggingParent;
    private Transform _originalParent;
    private GameObject _placeholder;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Init(Transform draggingParent)
    {
        _draggingParent = draggingParent;
        _originalParent = transform.parent;
    }

    public void Render(Iitem item)
    {
        _iconImage.sprite = item.UIIcon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _placeholder = new GameObject();
        _placeholder.transform.SetParent(_originalParent);

        LayoutElement layout = _placeholder.AddComponent<LayoutElement>();
        Image element = _placeholder.AddComponent<Image>();
        layout.transform.localScale = new Vector3(1, 1, 1);
        layout.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        layout.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        layout.flexibleWidth = 0;
        layout.flexibleHeight = 0;

        _placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());
        
        transform.parent = _draggingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = _originalParent;
        transform.SetSiblingIndex(_placeholder.transform.GetSiblingIndex());
        Destroy(_placeholder);
    }
}
