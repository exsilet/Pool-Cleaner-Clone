using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> _items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _draggingParent;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Bucket _bucket;

    private void OnEnable()
    {
        Render(_items);
    }

    public void Render(List<AssetItem> items)
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Init(_draggingParent);
            cell.Render(item);

            cell.Ejecting += () => Instantiate(item.UIitem, _spawn.position, Quaternion.identity);
            cell.Ejecting += () => _bucket.SaveColor(item);
        });
    }
}
