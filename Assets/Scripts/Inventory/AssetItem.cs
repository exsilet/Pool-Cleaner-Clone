using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : ScriptableObject, Iitem
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _bottle;
    [SerializeField] private Color _color;

    public string Name => _name;

    public Sprite UIIcon => _icon;

    public GameObject UIitem => _bottle;

    public Color UIcolor => _color;
}