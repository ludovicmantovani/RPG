using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTable : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    void Update()
    {
        transform.Rotate(0, _speed, 0);
    }
}
