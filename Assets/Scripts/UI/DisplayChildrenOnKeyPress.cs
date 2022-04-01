using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayChildrenOnKeyPress : MonoBehaviour
{
    [SerializeField] private bool _defaultDisplayState = false;
    [SerializeField] private KeyCode _triggerKeyCode;

    private bool _currentDisplayState;

    private void Start()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(_defaultDisplayState);
        _currentDisplayState = _defaultDisplayState;
    }
    void Update()
    {
        if (Input.GetKeyDown(_triggerKeyCode))
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(!_currentDisplayState);
            _currentDisplayState = !_currentDisplayState;
        }
    }

}
