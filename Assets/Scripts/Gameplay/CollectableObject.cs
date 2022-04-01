using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private string _keyName, _message;
    [SerializeField] private float _seconds = 2f;

    [SerializeField] private Dialogue _dialogueUIText;
    [SerializeField] private bool _disableAfterCollect = true;

    private void Start()
    {
        if (!_keyName.Equals("") && PlayerPrefs.GetString(_keyName, "Disabled") == "Active" && _disableAfterCollect)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (!_keyName.Equals(""))
            {
                PlayerPrefs.SetString(_keyName, "Active");
                if (_disableAfterCollect)
                    gameObject.SetActive(false);
            }
            if (!_message.Equals(""))
                _dialogueUIText.Display(_message, _seconds);
            
        }
    }
}
