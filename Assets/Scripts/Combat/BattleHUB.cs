using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUB : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Slider _hpSlider;

    public void SetHUB(Unit unit)
    {
        _nameText.text = unit.Name;
        _levelText.text = "Lvl " + unit.Level;
        _hpSlider.maxValue = unit.MaxHP;
        _hpSlider.value = unit.CurrentHP;
    }

    public void SetHP(int HP)
    {
        _hpSlider.value = HP;
    }
}
