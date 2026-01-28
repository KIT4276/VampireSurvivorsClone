using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectileFactory
{
    private List<Projectile> _activeProjectiles = new();

    [Inject]
    private Projectile.ProjectilePool _projectilesPool;

    public Projectile SpawnProjectile(Transform weapon, bool isEnemy)
    {
        Vector3 dir = weapon.forward.normalized;

        var projectile = _projectilesPool.Spawn(dir, isEnemy);
        _activeProjectiles.Add(projectile);

        projectile.transform.SetPositionAndRotation(
            weapon.position, 
            weapon.rotation
            );

        return projectile;
    }

    public void DespawnProjectile(Projectile projectile)
    {
        _projectilesPool.Despawn(projectile);
        _activeProjectiles.Remove(projectile);
    }
}
