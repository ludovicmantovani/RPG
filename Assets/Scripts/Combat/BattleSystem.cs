using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField] private Button _arcButton;
    [SerializeField] private int _arcMinDamage = 0;
    [SerializeField] private int _arcMaxDamage = 4;

    [SerializeField] private Button _healButton;
    [SerializeField] private int _heal = 4;


    private Unit _playerUnit, _enemyUnit;

    private BattleState _state;
    void Start()
    {
        _state = BattleState.START;
        if (!PlayerPrefs.HasKey("Arc"))
            _arcButton.interactable = false;

        if (!PlayerPrefs.HasKey("Santee"))
            _healButton.interactable = false;

        StartCoroutine(CreateBattle());
    }

    IEnumerator CreateBattle()
    {
        _playerUnit = Instantiate(_playerPrefab, _playerBattleStation).GetComponent<Unit>();
        _enemyUnit = Instantiate(_enemyPrefab, _enemyBattleStation).GetComponent<Unit>();

        if (PlayerPrefs.HasKey("CurrentEnemy"))
        {
            string enemyName = PlayerPrefs.GetString("CurrentEnemy");
            int enemyPV = PlayerPrefs.GetInt(enemyName);
            _enemyUnit.Name = enemyName;
            _enemyUnit.MaxHP = enemyPV;
            _enemyUnit.CurrentHP = enemyPV;
        }

        _dialogue.text = _enemyUnit.Name + " vous attaque !";

        _enemyHUB.SetHUB(_enemyUnit);
        _playerHUB.SetHUB(_playerUnit);

        yield return new WaitForSeconds(2f);

        _state = BattleState.PLAYERTURN;

        PlayerTurn();
    }

    public void PlayerTurn()
    {
        _dialogue.text = "Choisis une action :";

    }

    public void OnPunchAttackButton()
    {
        if (_state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(
            PlayerAttack(
                Random.Range(_playerUnit.MinDamage, _playerUnit.MaxDamage + 1)));
    }


    public void OnArcAttackButton()
    {
        if (_state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(
            PlayerAttack(
                _playerUnit.MinDamage + Random.Range(_arcMinDamage, _arcMaxDamage + 1)));
    }

    public void OnHealButton()
    {
        if (_state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {

        _playerUnit.Heal(_heal);
        _playerHUB.SetHP(_playerUnit.CurrentHP, _playerUnit.MaxHP);

        _dialogue.text = _playerUnit.Name + " a gagné " + _heal + "PV.";
        yield return new WaitForSeconds(2f);

        _state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerAttack(int damage)
    {
        bool isDead = _enemyUnit.TakeDamage(damage);

        _enemyHUB.SetHP(_enemyUnit.CurrentHP, _enemyUnit.MaxHP);
        _dialogue.text = _enemyUnit.Name + " a perdu " + damage + "PV.";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            _state = BattleState.WON;
            EndBattle();
        }
        else
        {
            _state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle()
    {
        PlayerPrefs.SetInt(_enemyUnit.Name, _enemyUnit.CurrentHP);
        PlayerPrefs.DeleteKey("CurrentEnemy");
        if (_state == BattleState.WON)
        {
            PlayerPrefs.DeleteKey(_enemyUnit.Name);
            _dialogue.text = "Vous avez gagné !";
        }
        else if (_state == BattleState.LOST)
        {
            _dialogue.text = "Vous avez perdu !";
        }
        StartCoroutine(ReturnToScene());
    }


    IEnumerator ReturnToScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(PlayerPrefs.GetString("Localisation"));
    }

    IEnumerator EnemyTurn()
    {
        _dialogue.text = _enemyUnit.Name + " attaque !";

        yield return new WaitForSeconds(2f);

        int damage = Random.Range(_enemyUnit.MinDamage, _enemyUnit.MaxDamage + 1);
        bool isDead = _playerUnit.TakeDamage(damage);
        
        _playerHUB.SetHP(_playerUnit.CurrentHP, _playerUnit.MaxHP);

        _dialogue.text = _playerUnit.Name + " a perdu " + damage + "PV.";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            _state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            _state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

}
