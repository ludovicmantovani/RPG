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

    [SerializeField] private List<EnemyController> _enemyControllers;


    void Start()
    {
        PlayerPrefs.DeleteKey("Start"); // TODO delete me
        //_changeLevelTrigger.CanChangeLevel = false;
        if (!PlayerPrefs.HasKey("Start")) // Si nouvelle partie
        {
            PlayerPrefs.SetFloat("Start", Time.time);
            _dialogueText.Display(_startingDialogInfo);
        }

        foreach (var enemyController in _enemyControllers)
        {
            if (PlayerPrefs.GetInt(enemyController.Name, 0) <= 0)
                enemyController.gameObject.SetActive(false);
        }
            
    }


    void Update()
    {
        
    }
}
