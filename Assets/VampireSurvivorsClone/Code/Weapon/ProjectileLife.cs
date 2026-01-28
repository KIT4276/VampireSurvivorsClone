using UnityEngine;
using Zenject;

[RequireComponent(typeof(ProjectileMove), typeof(Collider), typeof(ProjectileCollision))]
public class ProjectileLife : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private ProjectileMove _projectileMove;

    private ProjectilePool _pool;

    [Inject]
    private void Construct(ProjectilePool pool) => 
        _pool = pool;

    public void SetDirection(Vector3 worldDirection) => 
        _projectileMove.SetDirection(worldDirection);

    private void OnEnable()
    {
        if (_lifeTime > 0f)
            Invoke(nameof(Despawn), _lifeTime);
    }

    public void Despawn() =>
         _pool.Despawn(this);

    private void OnDisable() => 
        CancelInvoke(nameof(Despawn));

    public class ProjectilePool : MonoMemoryPool<Vector3, ProjectileLife> 
    {
        //protected override void OnCreated(ProjectileLife item) // AI
        //{
        //    item.Construct(this);

        //    if (item._projectileMove == null)
        //        item._projectileMove = item.GetComponent<ProjectileMove>();
        //}

        protected override void Reinitialize(Vector3 worldDirection, ProjectileLife item)//AI
        {
            item.SetDirection(worldDirection);
        }

        protected override void OnDespawned(ProjectileLife item) //AI
        {
            //TODO item.ResetState();
        }
    }

}
