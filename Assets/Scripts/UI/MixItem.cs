using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixItem : MonoBehaviour
{
    [SerializeField] private MeshRenderer _currentOject;
    [SerializeField] private Image _item1;
    [SerializeField] private Image _item2;
    [SerializeField] private Transform _containerSmallItem;
    [SerializeField] private Transform _containerBigItem;
    [SerializeField] private List<AssetMixItem> _mixItems;
    [SerializeField] private Pool _pool;

    private void OnEnable()
    {
        _pool.MateriaLChanged += CheckColor;
    }

    private void OnDisable()
    {
        _pool.MateriaLChanged -= CheckColor;
    }

    public void CheckColor(Material material)
    {
        for (int i = 0; i < _mixItems.Count; i++)
        {
            if(_mixItems[i].UImaterial == material)
            {
                _item1.sprite = _mixItems[i].UIIcon;
                _item2.sprite = _mixItems[i].UIIcon2;
            }
        }
    }
}
