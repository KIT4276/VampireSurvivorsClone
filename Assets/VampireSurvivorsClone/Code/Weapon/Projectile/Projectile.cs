using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileLife _projectileLife;
    [SerializeField] private ProjectileCollision _collision;

    [SerializeField] private ProjectileMove _projectileMove;
    [SerializeField] private ProjectileView _projectileView;

    private ProjectilePool _pool;
    private bool _isInPool;

    [Inject]
    private void Construct(ProjectilePool pool)
    {
        _pool = pool;
        _projectileLife.Init(this);
        _collision.Init(this);
    }

    public void SpawnInit(Vector3 worldDirection, bool isEnemy)
    {
        _isInPool = false;

        _projectileMove.SpawnInit(worldDirection);
        _projectileView.SpawnInit(isEnemy);
        _collision.SpawnInit(isEnemy);
    }

    public void Despawn()
    {
        if (_isInPool) return;

        _isInPool = true;
        _pool.Despawn(this);
    }

    public class ProjectilePool : MonoMemoryPool<Vector3, bool, Projectile>
    {
        protected override void Reinitialize(Vector3 worldDirection, bool isEnemy, Projectile item) //AI
        {
            item.SpawnInit(worldDirection, isEnemy);
        }

        //protected override void OnDespawned(Projectile item) //AI нашёл свою же ошибку:
                                                             //переопределила, но не вызвала  base.OnDespawned(item);
        //{
        //    base.OnDespawned(item);
        //    //TODO item.ResetState();
        //}
    }
}
