using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameObject _heroPrefab;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerInput>()
            .AsSingle();

        InstallHero();

    }

    private void InstallHero()
    {
        Container.Bind<HeroRoot>()
        .FromComponentInNewPrefab(_heroPrefab)
        .AsSingle()
        .NonLazy();


        Container.Bind<HeroMove>()
        .FromResolveGetter<HeroRoot>(root =>
            root.GetComponentInChildren<HeroMove>(true))
        .AsSingle();

        //todo other hero
    }
}