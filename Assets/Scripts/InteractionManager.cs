using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class InteractionManager : MonoBehaviour
{

    [SerializeField] Dialogue _dialogueText;
    [SerializeField] ChangeLevel _changeLevelTrigger;

    [SerializeField] string _startingDialogInfo;


    void Start()
    {
        _changeLevelTrigger.CanChangeLevel = false;
        if (!PlayerPrefs.HasKey("Start")) // Si nouvelle partie
        {
            PlayerPrefs.SetFloat("Start", Time.time);
            _dialogueText.Display(_startingDialogInfo);
        }
            
    }


    void Update()
    {
        
    }
}
