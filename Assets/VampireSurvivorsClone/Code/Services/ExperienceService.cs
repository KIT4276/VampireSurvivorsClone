using System;
using UnityEngine;
using Zenject;

public class ExperienceService : IInitializable 
{
   public float Value { get; private set; }

    public event Action<float> ExperienceAdded;

    public void Initialize()
    {
        Value = 0;
        ExperienceAdded?.Invoke(Value);
    }

    public void AddExperience(float experienceValue)
    {
        Value += experienceValue;
        ExperienceAdded?.Invoke(Value);
    }
}
