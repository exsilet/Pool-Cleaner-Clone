using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mixer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;
    [SerializeField] private float _durationMixer = 0.01f;
    [SerializeField] private Slider _mixerTime;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Bucket _bucket;
    [SerializeField] private Material _mixColor;
    [SerializeField] private Material _currentColor;
    [SerializeField] private MeshRenderer _materialMixed;
    [SerializeField] private GameObject _cameraDop;
    [SerializeField] private GameObject _cameraOsnova;
    [SerializeField] private GameObject _waterBottle;

    private int _currentPoint;

    private void Start()
    {
        _mixerTime.gameObject.SetActive(true);
        _currentColor = _materialMixed.material;
        _mixerTime.value = 0;
        StartCoroutine(Filling());
    }

    private IEnumerator Filling()
    {

        while (_mixerTime.value != _points.Length)
        {
            Transform target = _points[_currentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _materialMixed.material = _mixColor;
                    Destroy(gameObject);
                    _mixerTime.gameObject.SetActive(false);
                    _cameraDop.SetActive(false);
                    _cameraOsnova.SetActive(true);
                }
            }
            _mixerTime.value = Mathf.MoveTowards(_mixerTime.value, _currentPoint, Time.deltaTime * _duration);
            _materialMixed.material.color = Color.Lerp(_materialMixed.material.color, _mixColor.color, _durationMixer * Time.deltaTime);

            yield return null;
            _waterBottle.SetActive(false);
        }
        
    }
}
