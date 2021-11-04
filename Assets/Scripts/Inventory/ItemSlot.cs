using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private InventoryCell _item;

    public ItemSlot(InventoryCell item)
    {
        _item = item;
    }
}
