using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformInitialization : MonoBehaviour
{
    [SerializeField] private string _createur;

    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private Vector3 _scale;

    public string Createur { get => _createur;}

    void Start()
    {
        Debug.Log(gameObject.transform.position);
        Debug.Log(gameObject.transform.rotation);
        Debug.Log(gameObject.transform.localScale);

        gameObject.transform.position += _position;
        gameObject.transform.rotation *= _rotation;
        gameObject.transform.localScale += _scale;
    }

    private void Update()
    {
        //gameObject.transform.position += _position;
        //gameObject.transform.rotation *= _rotation;
        //gameObject.transform.localScale += _scale;
    }
}
