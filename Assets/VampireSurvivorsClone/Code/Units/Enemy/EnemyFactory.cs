using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    private List<Enemy> _activeEnemies = new();

    private Enemy.EnemyPool _enemiesPool;
    private Transform _target;

    public EnemyFactory(Enemy.EnemyPool enemiesPool, Hero hero)
    {
        _enemiesPool = enemiesPool;
        _target = hero.transform;
    }

    public Enemy SpawnEnemy(Vector3 spawnPosition)
    {
        var enemy = _enemiesPool.Spawn(_target);
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