using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Image _experienceBarImage;

    private AnimatedLevelSystem _animatedLevelSystem;
    
    public void SetLevelSystem(AnimatedLevelSystem animatedLevelSystem)
    {
        _animatedLevelSystem = animatedLevelSystem;
        
        SetLevelNumber(animatedLevelSystem.GetLevelNumber());
        SetExperienceBarSize(animatedLevelSystem.GetExperienceNormalized());
        
        animatedLevelSystem.LevelChanged += OnLevelChanged;
        animatedLevelSystem.ExperienceChanged += OnExperienceChanged;
    }

    private void OnLevelChanged()
    {
        SetLevelNumber(_animatedLevelSystem.GetLevelNumber());
    }

    private void OnExperienceChanged()
    {
        SetExperienceBarSize(_animatedLevelSystem.GetExperienceNormalized());
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        _experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        _levelText.SetText($"Level {levelNumber.ToString()}");
    }
}