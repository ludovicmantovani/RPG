using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class InteractionManager : MonoBehaviour
{

    [SerializeField] private Dialogue _dialogueText;
    [SerializeField] private ChangeLevel _changeLevelTrigger;
    [SerializeField] private PlayerMovementController _playerMovementController;

    [SerializeField] private string _startingDialogInfo;
    [SerializeField] private Transform _startingPlayerLocation;


    void Start()
    {
        PlayerPrefs.DeleteKey("Start"); // TODO delete me
        //_changeLevelTrigger.CanChangeLevel = false;
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
