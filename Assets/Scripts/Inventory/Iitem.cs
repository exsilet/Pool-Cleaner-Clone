using UnityEngine;

public interface Iitem
{
    string Name { get; }

    Sprite UIIcon { get; }

    GameObject UIitem { get; }

    Color UIcolor { get; }
}
