using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private string _keyName, _message;
    [SerializeField] private float _seconds = 2f;

    [SerializeField] private Dialogue _dialogueUIText;

    private void Start()
    {
        if (PlayerPrefs.GetString(_keyName, "Disabled") == "Active")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerPrefs.SetString(_keyName, "Active");
            gameObject.SetActive(false);
            if (!_message.Equals(""))
                _dialogueUIText.Display(_message, _seconds);
        }
    }
}
