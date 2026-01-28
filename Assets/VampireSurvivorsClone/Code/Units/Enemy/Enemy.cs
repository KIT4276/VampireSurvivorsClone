using UnityEngine;
using Zenject;

[RequireComponent(typeof(EnemyMove))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;

    private EnemyPool _enemyPool;

    [Inject]
    private void Construct(EnemyPool enemyPool) =>
        _enemyPool = enemyPool;

    private void SetTarget(Transform target) =>
        _enemyMove.SetTarget(target);

    public class EnemyPool : MonoMemoryPool<Transform, Enemy>
    {

        protected override void Reinitialize(Transform target, Enemy item)//AI
        {
            item.SetTarget(target);
        }

        protected override void OnDespawned(Enemy item) //AI
        {
            //TODO item.ResetState();
        }
    }
}
