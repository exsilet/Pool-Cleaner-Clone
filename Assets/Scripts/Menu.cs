using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _firstChemical;
    [SerializeField] private GameObject _secondChemical;

    //private void Start()
    //{
    //    _firstChemical.SetActive(false);
    //    _secondChemical.SetActive(false);
    //}

    public void OpenPanelFirstChemikal()
    {
        _secondChemical.SetActive(false);
        _firstChemical.SetActive(true);
    }

    public void OpenPanelSecondChemicals()
    {
        _firstChemical.SetActive(false);
        _secondChemical.SetActive(true);
    }
}
