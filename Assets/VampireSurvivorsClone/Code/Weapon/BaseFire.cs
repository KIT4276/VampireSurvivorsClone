using System;
using UnityEngine;

public class BaseFire : MonoBehaviour
{
    [SerializeField] private float _rateOfFire = 3;
    [SerializeField] private Transform _weapon;

    private ProjectileFactory _projectileFactory;

    private float _nextShotTime;

    public void Init(ProjectileFactory projectileFactory)
    {
        _projectileFactory = projectileFactory;
    }

    private void Update()
    {
        TryShoot();
    }

    private void TryShoot() //AI
    {
        if (_projectileFactory == null)
            return;

        float fireInterval = 1f / _rateOfFire;

        if (Time.time < _nextShotTime)
            return;

        _nextShotTime = Time.time + fireInterval;

        _projectileFactory.SpawnProjectile(_weapon);
    }
}
