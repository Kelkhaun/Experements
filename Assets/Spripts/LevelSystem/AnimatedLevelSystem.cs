using System;
using UnityEngine;

public class AnimatedLevelSystem
{
    private LevelSystem _levelSystem;
    private bool _isAnimated;

    private int _level;
    private int _experience;
    private float _updateTimerMax = .01f;
    private float _updateTimer;

    public event Action ExperienceChanged;
    public event Action LevelChanged;

    public AnimatedLevelSystem(LevelSystem levelSystem)
    {
        SetLevelSystem(levelSystem);
    }

    public void Update()
    {
        if (_isAnimated)
        {
            _updateTimer += Time.deltaTime;

            while (_updateTimer > _updateTimerMax)
            {
                _updateTimer -= _updateTimerMax;
                UpdateAddExperience();
            }
        }
    }

    private void UpdateAddExperience()
    {
        if (_level < _levelSystem.GetLevelNumber())
        {
            AddExperience();
        }
        else
        {
            if (_experience < _levelSystem.GetExperience())
            {
                AddExperience();
            }
            else
            {
                _isAnimated = false;
            }
        }
    }

    private void AddExperience()
    {
        _experience++;

        if (_experience >= _levelSystem.GetExperienceToNextLevel(_level))
        {
            _level++;
            _experience = 0;

            LevelChanged?.Invoke();
        }

        ExperienceChanged?.Invoke();
    }

    private void SetLevelSystem(LevelSystem levelSystem)
    {
        _levelSystem = levelSystem;
        _level = _levelSystem.GetLevelNumber();
        _experience = _levelSystem.GetExperience();

        _levelSystem.ExperienceChanged += OnExperienceChanged;
        _levelSystem.LevelChanged += OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        _isAnimated = true;
    }

    private void OnExperienceChanged()
    {
        _isAnimated = true;
    }

    public int GetLevelNumber()
    {
        return _level;
    }

    public float GetExperienceNormalized()
    {
        if (_levelSystem.IsMaxLevel(_level))
            return 1f;
        else
            return (float) _experience / _levelSystem.GetExperienceToNextLevel(_level);
    }
}