using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health;
    private int _maxHealth;
    private int _healthStep;

    public event Action<int> OnHealthChange;

    public int Health => _health;

    private void OnEnable()
    {
        _health = 90;
        _maxHealth = 100;
        _healthStep = 10;
    }

    public void Healing()
    {
        _health += _healthStep;

        if (_health > _maxHealth)
            _health = _maxHealth;

        OnHealthChange.Invoke(_health);
    }

    public void Punch()
    {
        _health -= _healthStep;

        if (_health < 0)
            _health = 0;

        OnHealthChange.Invoke(_health);
    }
}