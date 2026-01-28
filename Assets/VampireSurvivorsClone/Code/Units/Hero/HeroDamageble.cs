using System;
using UnityEngine;

public class HeroDamageble : MonoBehaviour, IDamageble
{
    [SerializeField] private float _totalHealth = 100;
    public bool IsEnemy => false; 

    private float _currentHealth;

    public event Action<float, float> HealthChanged;

    private void Awake()
    {
        _currentHealth = _totalHealth;
        HealthChanged?.Invoke(_currentHealth, _totalHealth);
    }

    public void TakeDamage(float value)
    {
        _currentHealth -= value;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            //TODO Death
        }
        HealthChanged?.Invoke(_currentHealth, _totalHealth);
    }
}

