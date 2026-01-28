using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ExperienceTrigger))]
public class ExperienceForEnemy : MonoBehaviour
{
    [SerializeField] private ExperienceTrigger _experienceTrigger; 

    private ExperienceForEnemyPool _pool;

    public float ExperienceValue {  get; private set; }

    [Inject]
    public void Construct(ExperienceForEnemyPool pool, ExperienceService experienceService)
    {
        _pool = pool;
        _experienceTrigger.Init(this, experienceService);
    }

    public void Despawn()
    {
        _pool.Despawn(this);
    }

    private void SpawnInit(float experience, Vector3 position)
    {
        ExperienceValue = experience;
        transform.position = position;
    }

    public class ExperienceForEnemyPool : MonoMemoryPool<Vector3,float, ExperienceForEnemy>
    {
        protected override void Reinitialize(Vector3 position, float experience, ExperienceForEnemy item)//AI
        {
            item.SpawnInit(experience, position);
        }
    }
}
