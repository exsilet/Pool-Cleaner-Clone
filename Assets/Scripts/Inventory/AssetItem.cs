using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : ScriptableObject, Iitem
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public Sprite UIIcon => _icon;
}
