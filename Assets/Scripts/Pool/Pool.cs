using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pool : MonoBehaviour
{
    [SerializeField] private List<Material> _poolMaterial;
    [SerializeField] private MeshRenderer _currentObject;
    [SerializeField] private Material _currentMaterial;

    private int randMaterial;
    public event UnityAction<Material> MateriaLChanged;

    private void Start()
    {
        RandomColor();
        MateriaLChanged?.Invoke(_currentMaterial);
    }

    public void RandomColor()
    {
        randMaterial = Random.Range(0, _poolMaterial.Count);
        _currentMaterial = _poolMaterial[randMaterial];
        _currentObject.material = _currentMaterial;
        MateriaLChanged?.Invoke(_currentMaterial);
    }
}
