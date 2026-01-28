using System.Collections.Generic;
using UnityEngine;
using static ExperienceForEnemy;

public class EnemyFactory
{
    private List<Enemy> _activeEnemies = new();

    private Enemy.EnemyPool _enemiesPool;
    private Transform _target;
    private ExperienceForEnemyPool _expPool;

    public EnemyFactory(Enemy.EnemyPool enemiesPool, Hero hero, ExperienceForEnemyPool expPool)
    {
        _enemiesPool = enemiesPool;
        _target = hero.transform;
        _expPool = expPool;
    }

    public Enemy SpawnEnemy(Vector3 spawnPosition)
    {
        var enemy = _enemiesPool.Spawn(_target, _expPool);
        _activeEnemies.Add(enemy);

        enemy.transform.SetPositionAndRotation(
            spawnPosition,
            Quaternion.identity
            );

        return enemy;
    }

    public void DespawnEnemy(Enemy enemy)
    {
        _enemiesPool.Despawn(enemy);
        _activeEnemies.Remove(enemy);
    }
}