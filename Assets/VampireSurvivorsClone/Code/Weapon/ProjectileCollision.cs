using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] private ProjectileLife _projectileLife;
    [SerializeField] private int _damage = 1;// - в конфиги

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageble>(out var damageble))
        {
            damageble.TakeDamage(_damage);
            _projectileLife.Despawn();
        }
    }
}
