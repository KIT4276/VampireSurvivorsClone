using System;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] private int _damage = 1;// - в конфиги

    private Projectile _projectile;
    private bool _isEnemy;

    public void Init(Projectile projectile) => 
        _projectile = projectile;

    public void SpawnInit(bool isEnemy) => 
        _isEnemy = isEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageble>(out var damageble) &&
            damageble.IsEnemy != _isEnemy)
        {
            damageble.TakeDamage(_damage);
            _projectile.Despawn();
        }
    }
}
