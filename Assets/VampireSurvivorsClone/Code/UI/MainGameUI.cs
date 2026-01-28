using System;
using TMPro;
using UnityEngine;
using Zenject;

public class MainGameUI : MonoBehaviour, IInitializable, ILateDisposable
{
    [SerializeField] private HPBar _hpBar;
    [SerializeField] private TMP_Text _expText;

    private HeroDamageble _heroDamageble;
    private ExperienceService _experienceService;

    [Inject]
    private void Construct(HeroDamageble heroDamageble, ExperienceService experienceService)
    {
        _heroDamageble = heroDamageble;
        _experienceService = experienceService;
    }
    private void Awake()
    {
        _expText.text = "0";
    }

    public void Initialize()
    {
        _heroDamageble.HealthChanged += OnHealthChange;
        _experienceService.ExperienceAdded += OnExperienceAdded;
    }

    private void OnExperienceAdded(float value)
    {
        _expText.text = value.ToString();
    }

    private void OnHealthChange(float current, float total)
    {
        _hpBar.SetHP(current, total);
    }

    public void LateDispose()
    {
        _heroDamageble.HealthChanged -= OnHealthChange;
        _experienceService.ExperienceAdded -= OnExperienceAdded;
    }
}
