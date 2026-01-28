using System;
using UnityEngine;
using static ExperienceForEnemy;

public class EnemyDamageble : MonoBehaviour, IDamageble
{
    [SerializeField] private HPBar _hpBar;
    [SerializeField] private float _totalHP = 10;
    public bool IsEnemy => true;

    private float _currentHealth;
    private ExperienceForEnemyPool _experienceForEnemyPool;
    private Enemy _enemy;

    private void Awake()
    {
        _currentHealth = _totalHP;
        _hpBar.SetHP(_currentHealth, _totalHP);
    }

    public void SpawnInit(ExperienceForEnemyPool experienceForEnemyPool, Enemy enemy)
    {
        _experienceForEnemyPool = experienceForEnemyPool;
        _enemy = enemy;
    }

    public void TakeDamage(float value)
    {
        _currentHealth -= value;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Death();
        }
        _hpBar.SetHP(_currentHealth, _totalHP);
    }

    private void Death()
    {
        _experienceForEnemyPool.Spawn(transform.position, _enemy.Exp);
        _enemy.Despawn();
    }
}
