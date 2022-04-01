using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private string _ActivationKeyName;
    [SerializeField] private string _sceneToLoad;
    [SerializeField] private SwitchSceneManager _switchSM;

    [SerializeField] private Dialogue _dialogue;
    [SerializeField] private string _closedText = "Impossible de sortir";
    [SerializeField] private float _closedTextDuration = 5f;

    [SerializeField] private bool _canChangeLevel = false;

    public bool CanChangeLevel {set => _canChangeLevel = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (PlayerPrefs.GetString(_ActivationKeyName, "Disabled") == "Active")
            {
                SceneManager.LoadScene(_sceneToLoad);
            }
            else
            {
                if (_dialogue)
                {
                    _dialogue.Display(_closedText, _closedTextDuration);
                }
            }
            
        }
    }
}
