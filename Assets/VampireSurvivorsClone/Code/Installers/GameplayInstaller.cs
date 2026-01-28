using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private GameObject _projectilePrefab;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerInput>()
            .AsSingle();

        Container.Bind<ProjectileFactory>()
            .AsSingle();

        InstallHero();
        InstallProjectilePool();
    }

    private void InstallProjectilePool()
    {
        Container.BindMemoryPool<ProjectileLife, ProjectileLife.Pool>()
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