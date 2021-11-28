using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MixerColor")]
public class AssetMixItem : ScriptableObject
{
    [SerializeField] private Material _createMaterial;
    [SerializeField] private Sprite _icon1;
    [SerializeField] private Sprite _icon2;

    public Material UImaterial => _createMaterial;
    public Sprite UIIcon => _icon1;
    public Sprite UIIcon2 => _icon2;
}
