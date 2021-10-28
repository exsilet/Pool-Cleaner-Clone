using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private AssetItem _item;

    public void Rander(AssetItem item)
    {
        _item = item;

        _image.sprite = _item.UIIcon;
    }
}
