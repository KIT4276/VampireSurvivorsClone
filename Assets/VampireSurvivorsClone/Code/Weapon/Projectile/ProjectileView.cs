using UnityEngine;

public class ProjectileView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [Space]
    [SerializeField] private Material _heroMaterial;
    [SerializeField] private Material _enemyMaterial;

    public void SpawnInit(bool isEnemy)
    {
        _renderer.sharedMaterial = isEnemy
        ? _enemyMaterial
        : _heroMaterial;
    }
}
