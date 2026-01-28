using System;
using UnityEngine;
using Zenject;
using static ExperienceForEnemy;

[RequireComponent(typeof(EnemyMove),typeof(BaseFire))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyDamageble _damageble;
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private BaseFire _fire;
    [SerializeField] private float _exp = 10;

    private EnemyPool _enemyPool;// for EnemyCollision may be
    public float Exp { get => _exp; }

    [Inject]
    private void Construct(EnemyPool enemyPool, ProjectileFactory projectileFactory)
    {
        _enemyPool = enemyPool;
        _fire.Init(projectileFactory);
    }

    public void Despawn()
    {
        _enemyPool.Despawn(this);
    }

    private void SpawnInit(Transform target, ExperienceForEnemyPool pool)
    {
        _enemyMove.SetTarget(target);
        _damageble.SpawnInit(pool, this);
    }

    public class EnemyPool : MonoMemoryPool<Transform, ExperienceForEnemyPool, Enemy>
    {

        protected override void Reinitialize(Transform target, ExperienceForEnemyPool pool, Enemy item)//AI
        {
            item.SpawnInit(target, pool);
        }

        //protected override void OnDespawned(Enemy item) //AI
        //{
        //    base.OnDespawned(item);
        //    //TODO item.ResetState();
        //}
    }
}
