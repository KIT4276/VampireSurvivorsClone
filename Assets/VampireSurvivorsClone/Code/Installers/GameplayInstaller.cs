using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemySpawnerPrefab;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerInput>()
            .AsSingle();

        Container.Bind<ProjectileFactory>()
            .AsSingle();

        InstallHero();
        InstallProjectilePool();

        Container.Bind<EnemyFactory>()
            .AsSingle();

        InstallEnemyPool();

        Container.Bind<EnemySpawner>()
            .FromComponentInNewPrefab(_enemySpawnerPrefab)
            .AsSingle()
            .NonLazy();
    }

    private void InstallEnemyPool()
    {
        Container.BindMemoryPool<Enemy, Enemy.EnemyPool>()
            .WithInitialSize(20)
            .FromComponentInNewPrefab(_enemyPrefab)
            .UnderTransformGroup("Enemies");

    }

    private void InstallProjectilePool()
    {
        Container.BindMemoryPool<ProjectileLife, ProjectileLife.ProjectilePool>()
           .WithInitialSize(20)
           .FromComponentInNewPrefab(_projectilePrefab)
           .UnderTransformGroup("Projectiles");
    }

    private void InstallHero()
    {
        Container.Bind<HeroRoot>()
        .FromComponentInNewPrefab(_heroPrefab)
        .AsSingle()
        .NonLazy();


        Container.Bind<Hero>()
        .FromResolveGetter<HeroRoot>(root =>
            root.GetComponentInChildren<Hero>(true))
        .AsSingle();
    }
}