using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private EnemyFactory _enemyFactory;

    [Inject]
    private void Construct(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }


    private void Awake()
    {
        _enemyFactory.SpawnEnemy(new Vector3(-26, 0, -6));
        _enemyFactory.SpawnEnemy(new Vector3(14, 0, -14));
        _enemyFactory.SpawnEnemy(new Vector3(25, 0, 16));
        _enemyFactory.SpawnEnemy(new Vector3(-12, 0, 6));
    }
}
