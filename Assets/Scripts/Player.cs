using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health;
    private int _maxHealth;
    private int _minHealth;
    private int _healthStep;

    public event Action<int> HealthChanged;

    public int Health => _health;

    private void OnEnable()
    {
        _health = 90;
        _maxHealth = 100;
        _minHealth = 0;
        _healthStep = 10;
    }

    public void Healing() => ChangeHealth(_healthStep);

    public void Punch() => ChangeHealth(-_healthStep);

    private void ChangeHealth(int value)
    {
        _health = Mathf.Clamp(_health + value, _minHealth, _maxHealth);

        HealthChanged.Invoke(_health);
    }
}