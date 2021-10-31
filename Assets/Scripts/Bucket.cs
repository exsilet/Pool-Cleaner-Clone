using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bucket : MonoBehaviour
{
    [SerializeField] private List<AssetItem> _item;
    [SerializeField] private Material _mixColorMaterial = default;
    [SerializeField] private int _maxColor;
    [SerializeField] private int _minColor;
    [SerializeField] private MeshRenderer _materialMixed;

    public void SaveColor(AssetItem item)
    {
        _item.Capacity = _maxColor;

        if (_item.Count < _maxColor || _item.Count > _minColor)
        {
            _item.Add(item);
        }
        else
        {
            _item.Clear();
            _item.Add(item);
        }
    }

    public void ColorMix()
    {
        Color chemicalBottle1, chemicalBottle2;

        chemicalBottle1 = _item[0].UIcolor;
        chemicalBottle2 = _item[1].UIcolor;

        _mixColorMaterial.color = ColorMixing(chemicalBottle1, chemicalBottle2);

        _materialMixed.material = _mixColorMaterial;
    }

    public Color ColorMixing(Color color1, Color color2)
    {
        //int _r = ((int)((color1.r + color2.r) / 2));
        //int _g = ((int)((color1.g + color2.g) / 2));
        //int _b = ((int)((color1.b + color2.b) / 2));

        //return new Color(Convert.ToByte(_r),
        //                 Convert.ToByte(_g),
        //                 Convert.ToByte(_b));

        var newColor = (color1 + color2) / 2.0f;
        return newColor;
    }
}
