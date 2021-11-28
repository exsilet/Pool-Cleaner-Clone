using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Bottle : MonoBehaviour
{
    [SerializeField] private readonly ParticleSystem _water;

    private Animator _animator;

    public event UnityAction Dying;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DeletingObject()
    {
        Destroy(gameObject);
        Dying?.Invoke();
    }
}
