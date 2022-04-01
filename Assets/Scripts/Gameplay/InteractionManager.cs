using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class InteractionManager : MonoBehaviour
{

    [SerializeField] private Dialogue _dialogueText;
    [SerializeField] private PlayerMovementController _playerMovementController;

    [SerializeField] private string _startingDialogInfo;

    [SerializeField] private List<EnemyController> _enemyControllers;


    void Start()
    {
        if (!PlayerPrefs.HasKey("Start" + SceneManager.GetActiveScene().name))
        {
            PlayerPrefs.SetFloat("Start" + SceneManager.GetActiveScene().name, Time.time);
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
