using System;
using UnityEngine;

public abstract class BaseFire : MonoBehaviour
{
    [SerializeField] protected float _rateOfFire = 3;
    [SerializeField] protected Transform _weapon;

    protected ProjectileFactory _projectileFactory;

    protected float _nextShotTime;

    public void Init(ProjectileFactory projectileFactory)
    {
        _projectileFactory = projectileFactory;
    }

    protected void Update() => 
        TryShoot();

    protected void TryShoot() //AI
    {
        if (_projectileFactory == null)
            return;

        float fireInterval = 1f / _rateOfFire;

        if (Time.time < _nextShotTime)
            return;

        _nextShotTime = Time.time + fireInterval;

        Shoot();
    }

    protected abstract void Shoot();
}
