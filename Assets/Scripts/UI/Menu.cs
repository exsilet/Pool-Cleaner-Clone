using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Transform _inventorySmallBottle;
    [SerializeField] private Transform _inventoryBigBottle;
    [SerializeField] private Button _buttonMixer;
    [SerializeField] private Button _buttonPourOut;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<AssetItem> _item;

    private void Start()
    {
        _inventorySmallBottle.gameObject.SetActive(true);
        _inventoryBigBottle.gameObject.SetActive(false);
    }
}
