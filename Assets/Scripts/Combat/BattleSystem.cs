using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Etats possibles
public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab, _enemyPrefab;
    [SerializeField] private Transform _playerBattleStation, _enemyBattleStation;

    [SerializeField] private Text _dialogue;

    [SerializeField] private BattleHUB _enemyHUB;
    [SerializeField] private BattleHUB _playerHUB;


    private Unit _playerUnit, _enemyUnit;

    private BattleState _state;
    void Start()
    {
        _state = BattleState.START;
        CreateBattle();
    }

    private void CreateBattle()
    {
        _playerUnit = Instantiate(_playerPrefab, _playerBattleStation).GetComponent<Unit>();
        _enemyUnit = Instantiate(_enemyPrefab, _enemyBattleStation).GetComponent<Unit>();

        _dialogue.text = _enemyUnit.Name + " vous attaque !";

        _enemyHUB.SetHUB(_enemyUnit);
        _playerHUB.SetHUB(_playerUnit);
    }
}
