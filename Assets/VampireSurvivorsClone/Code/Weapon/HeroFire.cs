
using UnityEngine;

public class HeroFire : BaseFire
{
    protected override void Shoot()
    {
        _projectileFactory.SpawnProjectile(_weapon, false);
    }
}
