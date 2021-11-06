using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Bucket : MonoBehaviour
{
    [SerializeField] private List<AssetItem> _item;
    [SerializeField] private Material _mixColorMaterial = default;
    [SerializeField] private int _maxColor;
    [SerializeField] private int _minColor;
    [SerializeField] private MeshRenderer _materialMixed;
    [SerializeField] private GameObject _buttonMixer;
    [SerializeField] private GameObject _cameraDop;
    [SerializeField] private GameObject _cameraOsnova;
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _waterBucker;

    private Animator _animator;
    private const string PourOut = "PourOut";

    private void Start()
    {
        _buttonMixer.SetActive(false);
        _animator = GetComponent<Animator>();
    }

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
        }

        if (_item.Count == _maxColor)
        {
            _buttonMixer.SetActive(true);
            _inventory.SetActive(false);
            _cameraOsnova.SetActive(false);
            _cameraDop.SetActive(true);
        }
    }

    public bool AddedColor()
    {
        foreach (AssetItem itemSlot in _item)
        {
            if (itemSlot.UIcolor == _item[0].UIcolor && itemSlot.UIcolor == _item[1].UIcolor)
                continue;

            return true;
        }

        return false;
    }

    public void ColorMix()
    {
        Color chemicalBottle1, chemicalBottle2;

        AddedColor();
        chemicalBottle1 = _item[0].UIcolor;
        chemicalBottle2 = _item[1].UIcolor;

        _buttonMixer.SetActive(true);
        _mixColorMaterial.color = ColorMixing(chemicalBottle1, chemicalBottle2);
        _materialMixed.material = _mixColorMaterial;
        _cameraDop.SetActive(false);
        _cameraOsnova.SetActive(true);
    }

    public Color ColorMixing(Color color1, Color color2)
    {
        var newColor = (color1 + color2) / 2.0f;
        return newColor;
    }

    public void PourOutChemicals()
    {
        _animator.SetTrigger(PourOut);
    }
}
