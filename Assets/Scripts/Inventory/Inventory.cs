using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> _items;
    [SerializeField] private GameObject _itemPregfab;

    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _containerSmallItem;
    [SerializeField] private Transform _containerBigItem;
    [SerializeField] private Transform _draggingParent;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Bucket _bucket;

    private void OnEnable()
    {
        Render(_items);
    }

    public void Render(List<AssetItem> items)
    {
        foreach (Transform child in _containerSmallItem)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            if (item.UIitem.name.StartsWith("Big"))
            {
                CraftinItem(item, _containerSmallItem);
            }
        });

        items.ForEach(item =>
        {
            if (item.UIitem.name.StartsWith("Small"))
            {
                CraftinItem(item, _containerBigItem);
            }
        });
    }

    private void CraftinItem(AssetItem item, Transform container)
    {
        var cell = Instantiate(_inventoryCellTemplate, container);
        cell.Init(_draggingParent);
        cell.Render(item);

        cell.Ejecting += () => Instantiate(item.UIitem, _spawn.position, Quaternion.identity);
        cell.Ejecting += () => _bucket.SaveColor(item);
    }
}
