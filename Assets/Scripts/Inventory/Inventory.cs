using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> _items;
    [SerializeField] private List<InventoryCell> _inventoryCell = new List<InventoryCell>();
    [SerializeField] private GameObject _itemPregfab;

    [SerializeField] private GameObject _panel;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _containerSmallItem;
    [SerializeField] private Transform _containerBigItem;
    [SerializeField] private Transform _draggingParent;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Bucket _bucket;

    //private int HorizontalCellsCount = 7;

    //private void Start()
    //{
    //    FillInventory();
    //}

    private void OnEnable()
    {
        Render(_items);
    }

    //public void FillInventory()
    //{
    //    for (int i = 0; i < HorizontalCellsCount; i++)
    //    {
    //        InventoryCell cell = Instantiate(_itemPregfab, _containerSmallItem).GetComponent<InventoryCell>();
    //        _inventoryCell.Add(cell);
    //    }
    //}

    public void Render(List<AssetItem> items)
    {
        foreach (Transform child in _containerSmallItem)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _containerSmallItem);
            cell.Init(_draggingParent);
            cell.Render(item);

            cell.Ejecting += () => Instantiate(item.UIitem, _spawn.position, Quaternion.identity);
            cell.Ejecting += () => _bucket.SaveColor(item);
        });

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _containerBigItem);
            cell.Init(_draggingParent);
            cell.Render(item);

            cell.Ejecting += () => Instantiate(item.UIitem, _spawn.position, Quaternion.identity);
            cell.Ejecting += () => _bucket.SaveColor(item);
        });
    }

    //public void UpdateCells()
    //{
    //    for (int i = 0; i < _inventoryCell.Count; i++)
    //    {
    //        _inventoryCell[i].UpdateCell();
    //    }
    //}
}
