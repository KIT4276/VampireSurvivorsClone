using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectileFactory
{
    private List<ProjectileLife> _activeProjectiles = new();

    [Inject]
    private ProjectileLife.ProjectilePool _projectilesPool;

    public ProjectileLife SpawnProjectile(Transform weapon)
    {
        Vector3 dir = weapon.forward.normalized;

        var projectile = _projectilesPool.Spawn(dir);
        _activeProjectiles.Add(projectile);

        projectile.transform.SetPositionAndRotation(
            weapon.position, 
            weapon.rotation
            );

        return projectile;
    }

    public void DespawnProjectile(ProjectileLife projectile)
    {
        _projectilesPool.Despawn(projectile);
        _activeProjectiles.Remove(projectile);
    }
}
