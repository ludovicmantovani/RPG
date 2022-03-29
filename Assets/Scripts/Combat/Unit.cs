using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _level, _damage, _maxHP, _currentHP;

    public string Name { get => _name; set => _name = value; }
    public int Level { get => _level; set => _level = value; }
    public int MaxHP { get => _maxHP; set => _maxHP = value; }
    public int CurrentHP { get => _currentHP; set => _currentHP = value; }
}
