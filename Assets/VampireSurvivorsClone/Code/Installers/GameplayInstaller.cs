using System;
using UnityEngine;
using Zenject;
using static ExperienceForEnemy;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemySpawnerPrefab;
    [SerializeField] private GameObject _mainUIPrefab;
    [SerializeField] private GameObject _experiencePrefab;

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

        Container.BindInterfacesAndSelfTo<ExperienceService>()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<MainGameUI>()
            .FromComponentInNewPrefab(_mainUIPrefab)
            .AsSingle()
            .NonLazy();
    }

    private void InstallEnemyPool()
    {
        Container.BindMemoryPool<ExperienceForEnemy, ExperienceForEnemy.ExperienceForEnemyPool>()
            .WithInitialSize(20)
            .FromComponentInNewPrefab(_experiencePrefab)
            .UnderTransformGroup("Experience");

        Container.BindMemoryPool<Enemy, Enemy.EnemyPool>()
            .WithInitialSize(20)
            .FromComponentInNewPrefab(_enemyPrefab)
            .UnderTransformGroup("Enemies");

    }

    private void InstallProjectilePool()
    {
        Container.BindMemoryPool<Projectile, Projectile.ProjectilePool>()
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

        Container.Bind<HeroDamageble>()
            .FromResolveGetter<HeroRoot>(root =>
            root.GetComponentInChildren<HeroDamageble>(true))
        .AsSingle();
    }
}