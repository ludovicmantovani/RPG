using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = _target.position;
    }
}