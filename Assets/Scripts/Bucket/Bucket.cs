using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Bucket : MonoBehaviour
{
    [SerializeField] private int _maxColor;
    [SerializeField] private int _minColor;
    [SerializeField] private List<AssetItem> _items;
    [SerializeField] private Material _mixColor;

    [SerializeField] private Transform _inventorySmallBottle;
    [SerializeField] private Transform _inventoryBigBottle;
    [SerializeField] private Inventory _inventoryObject;
    [SerializeField] private Mixer _mixingMachins;
    [SerializeField] private Button _buttonMixer;
    [SerializeField] private Button _buttonPourOut;
    [SerializeField] private Camera _cameraDop;
    [SerializeField] private Camera _cameraOsnova;
    [SerializeField] private GameObject _waterBottle;

    [SerializeField] private float _durationMixer;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private MeshRenderer _currentObject;

    private Animator _animator;
    private const string PourOut = "PourOut";

    private void Start()
    {
        _buttonMixer.gameObject.SetActive(false);
        _buttonPourOut.gameObject.SetActive(false);
        _animator = GetComponent<Animator>();
    }

    public void SaveColor(AssetItem item)
    {
        _items.Capacity = _maxColor;

        StartCoroutine(ChangeInventory(item));
    }

    private IEnumerator ChangeInventory(AssetItem item)
    {
        var waitForOneSeconds = new WaitForSeconds(1.3f);
        yield return waitForOneSeconds;

        if (_items.Count < _maxColor || _items.Count > _minColor)
        {
            _items.Add(item);
            ActiveInventory();

            if (_items.Count == _maxColor)
            {
                ActiveInventory();
            }
        }
    }

    public void ActiveInventory()
    {
        if (_inventorySmallBottle.gameObject.activeInHierarchy == true)
        {
            _inventorySmallBottle.gameObject.SetActive(false);
            _inventoryBigBottle.gameObject.SetActive(true);
            _waterBottle.SetActive(true);
        }
        else
        {
            _buttonMixer.gameObject.SetActive(true);
            _inventoryObject.gameObject.SetActive(false);
            _cameraDop.gameObject.SetActive(true);
            _buttonPourOut.gameObject.SetActive(true);
        }
    }

    public bool AddedColor()
    {
        foreach (AssetItem itemSlot in _items)
        {
            if (itemSlot.UIcolor == _items[0].UIcolor && itemSlot.UIcolor == _items[1].UIcolor)
                continue;

            return true;
        }

        return false;
    }

    public void ColorMix()
    {
        Color chemicalBottle1, chemicalBottle2;

        AddedColor();
        chemicalBottle1 = _items[0].UIcolor;
        chemicalBottle2 = _items[1].UIcolor;

        _mixingMachins.gameObject.SetActive(true);

        _mixColor.color = ColorMixing(chemicalBottle1, chemicalBottle2);
    }

    public Color ColorMixing(Color color1, Color color2)
    {
        var newColor = (color1 + color2) / 2.0f;
        return newColor;
    }

    public void PourOutChemicals()
    {
        _cameraDop.gameObject.SetActive(false);
        _cameraOsnova.gameObject.SetActive(true);
        _buttonMixer.gameObject.SetActive(false);

        _animator.Play(PourOut);
    }

    public void ChangeColor()
    {
        _currentObject.material.color = Color.Lerp(_currentObject.material.color, _normalMaterial.color, _durationMixer * Time.deltaTime);
        _currentObject.material = _normalMaterial;
    }
}
