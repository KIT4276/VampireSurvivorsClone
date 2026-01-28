using UnityEngine;
using Zenject;

[RequireComponent(typeof(BaseFire), typeof(HeroMove))]
public class Hero : MonoBehaviour
{
    [SerializeField] private BaseFire _fire;
    [SerializeField] private HeroMove _move;

    [Inject]
    public void PseudoConstruct(ProjectileFactory projectileFactory, PlayerInput playerInput)
    {
        _fire.Init(projectileFactory);
        _move.Init(playerInput);
    }
}
