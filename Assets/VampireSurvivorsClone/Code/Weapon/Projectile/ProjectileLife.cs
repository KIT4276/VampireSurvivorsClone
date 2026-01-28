using UnityEngine;

public class ProjectileLife : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;

    private Projectile _projectile;

    public void Init(Projectile projectile)
    {
        _projectile = projectile;
    }

    private void OnEnable()
    {
        if (_lifeTime > 0f)
            Invoke(nameof(Despawn), _lifeTime);
    }

    private void OnDisable() =>
       CancelInvoke(nameof(Despawn));


    public void Despawn()
    {
        //_projectile.Despawn();
    }
}
