using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private string _ActivationKeyName;
    [SerializeField] private string _ActivationKeyName2;
    [SerializeField] private string _sceneToLoad;
    [SerializeField] private SwitchSceneManager _switchSM;

    [SerializeField] private Dialogue _dialogue;
    [SerializeField] private string _closedText = "Impossible de sortir";
    [SerializeField] private float _closedTextDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (PlayerPrefs.GetString(_ActivationKeyName, "Disabled") == "Active")
            {
                if (!_ActivationKeyName2.Equals(""))
                {
                    if (PlayerPrefs.GetString(_ActivationKeyName2, "Disabled") == "Active")
                        SceneManager.LoadScene(_sceneToLoad);
                    else if (_dialogue)
                    {
                        _dialogue.Display(_closedText, _closedTextDuration);
                    }
                }
                else
                {
                    SceneManager.LoadScene(_sceneToLoad);
                }
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
