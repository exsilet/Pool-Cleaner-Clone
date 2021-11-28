using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private Image _background;

    private CanvasGroup _canvasGroup;
    private Transform _draggingParent;
    private Transform _originalParent;
    private GameObject _placeholder;

    public event Action Ejecting;
    
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
        _background.enabled = false;
        _placeholder = new GameObject();
        _placeholder.transform.SetParent(_originalParent);

        CreateProperties();

        _placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.parent = _draggingParent;
        _canvasGroup.blocksRaycasts = false;

        void CreateProperties()
        {
            LayoutElement layout = _placeholder.AddComponent<LayoutElement>();
            Image element = _placeholder.AddComponent<Image>();
            element.color = new Color(0.8627451f, 0.8627451f, 0.8627451f);
            _placeholder.transform.localScale = new Vector3(1, 1, 1);
            element.sprite = _background.sprite;
            layout.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            layout.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (In((RectTransform)_originalParent))
        {
            InsertInGrid();
        }
        else
        {
            InsertInGrid();
            Eject();
        }
    }

    public void Eject()
    {
        Ejecting?.Invoke();
    }

    public void InsertInGrid()
    {
        transform.parent = _originalParent;
        transform.SetSiblingIndex(_placeholder.transform.GetSiblingIndex());
        Destroy(_placeholder);
        _canvasGroup.blocksRaycasts = true;
        _background.enabled = true;
    }

    private bool In(RectTransform originalParent)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(originalParent, transform.position);
    }
}
