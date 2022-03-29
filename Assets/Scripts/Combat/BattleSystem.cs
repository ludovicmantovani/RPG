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

    [SerializeField] private Text _enemyName;
    [SerializeField] private Text _enemyLevel;
    [SerializeField] private Slider _enemyHP;

    [SerializeField] private Text _playerName;
    [SerializeField] private Text _playerLevel;
    [SerializeField] private Slider _playerHP;



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

        _enemyName.text = _enemyUnit.Name;
        _enemyLevel.text = "Lvl " + _enemyUnit.Level.ToString();
        _enemyHP.maxValue = _enemyUnit.MaxHP;
        _enemyHP.value = _enemyUnit.CurrentHP;



        _playerName.text = _playerUnit.Name;
        _playerLevel.text = "Lvl " + _playerUnit.Level.ToString();
        _playerHP.maxValue = _playerUnit.MaxHP;
        _playerHP.value = _playerUnit.CurrentHP;
    }
}
