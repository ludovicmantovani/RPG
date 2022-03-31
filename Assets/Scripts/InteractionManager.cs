using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class InteractionManager : MonoBehaviour
{

    [SerializeField] Text _dialogueText;
    [SerializeField] ChangeLevel _changeLevelTrigger;


    void Start()
    {
        _changeLevelTrigger.CanChangeLevel = false;
    }


    void Update()
    {
        
    }
}
