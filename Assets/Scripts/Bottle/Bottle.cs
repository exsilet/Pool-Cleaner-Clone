using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Bottle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _water;
    [SerializeField] private GameObject _waterActiv;

    private Animator _animator;
    private MeshRenderer _color;

    public event UnityAction<Bottle> Dying;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PourLiquid()
    {
        _waterActiv.SetActive(true);
        _water.Play();
    }

    public void DeletingObject()
    {
        Dying?.Invoke(this);
        Destroy(gameObject);
    }
}
