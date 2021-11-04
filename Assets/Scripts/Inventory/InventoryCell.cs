using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public event Action Ejecting;

    [SerializeField] private Image _iconImage;
    //[SerializeField] private AssetItem CurrentItem;
    //[SerializeField] private List<AssetItem> _items;

    private CanvasGroup _canvasGroup;
    private Transform _draggingParent;
    private Transform _originalParent;
    private GameObject _placeholder;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    //public void UpdateCell()
    //{
    //    for (int i = 0; i < _items.Count; i++)
    //    {
    //        if (_items[i] && _items[i].UIIcon)
    //        {
    //            _iconImage.sprite = _items[i].UIIcon;
    //            _iconImage.color = Color.white;
    //        }
    //        else
    //        {
    //            _iconImage.sprite = null;
    //            _iconImage.color = Color.clear;
    //        }
    //    }
    //}

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

        CreateProperties();

        _placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.parent = _draggingParent;
        _canvasGroup.blocksRaycasts = false;

        void CreateProperties()
        {
            LayoutElement layout = _placeholder.AddComponent<LayoutElement>();
            Image element = _placeholder.AddComponent<Image>();
            layout.transform.localScale = new Vector3(1, 1, 1);
            layout.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            layout.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            layout.flexibleWidth = 0;
            layout.flexibleHeight = 0;
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
    }

    private bool In(RectTransform originalParent)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(originalParent, transform.position);
    }
}
