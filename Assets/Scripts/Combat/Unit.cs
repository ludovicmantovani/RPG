using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _level, _minDamage, _maxDamage, _maxHP, _currentHP;

    public string Name { get => _name; set => _name = value; }
    public int Level { get => _level; set => _level = value; }
    public int MaxHP { get => _maxHP; set => _maxHP = value; }
    public int CurrentHP { get => _currentHP; set => _currentHP = value; }
    public int MinDamage { get => _minDamage; set => _minDamage = value; }
    public int MaxDamage { get => _maxDamage; set => _maxDamage = value; }

    public bool TakeDamage(int damage)
    {
        _currentHP -= damage;

        _currentHP = Mathf.Max(_currentHP, 0);
        return _currentHP == 0 ? true : false;
    }

    public void Heal(int amount)
    {
        _currentHP += amount;

        _currentHP = Mathf.Min(_currentHP, _maxHP);
    }
}
