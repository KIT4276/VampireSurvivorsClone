using UnityEngine;

public class ExperienceTrigger : MonoBehaviour
{
    private ExperienceForEnemy _experienceForEnemy;
    private ExperienceService _experienceService;

    public void Init(ExperienceForEnemy experienceForEnemy, ExperienceService experienceService)
    {
        _experienceForEnemy = experienceForEnemy;
        _experienceService = experienceService;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Hero>(out var hero))
        {
            _experienceService.AddExperience(_experienceForEnemy.ExperienceValue);
            _experienceForEnemy.Despawn();
        }
    }
}
