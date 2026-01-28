public class EnemyFire : BaseFire
{
    protected override void Shoot()
    {
        _projectileFactory.SpawnProjectile(_weapon, true);
    }
}
