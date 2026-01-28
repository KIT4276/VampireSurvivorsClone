using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _rateOfSpawn = 0.5f;
    [SerializeField] private float _spawnRadius = 40f;

    private EnemyFactory _enemyFactory;
    private Transform _hero;

    private float _nextSpawnTime;

    [Inject]
    private void Construct(EnemyFactory enemyFactory, Hero hero)
    {
        _enemyFactory = enemyFactory;
        _hero = hero.transform;
    }

    private void Update() => 
        TrySpawn();

    private void TrySpawn()//AI
    {
        float interval = 1f / _rateOfSpawn;

        if (Time.time < _nextSpawnTime)
            return;

        _nextSpawnTime = Time.time + interval;

        _enemyFactory.SpawnEnemy(GetSpawnPosition());
    }

    private Vector3 GetSpawnPosition() //AI
    {
        Vector2 circle = Random.insideUnitCircle.normalized * _spawnRadius;

        return new Vector3(
            _hero.position.x + circle.x,
            0f,
            _hero.position.z + circle.y
        );
    }
}
