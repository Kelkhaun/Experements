using System;
using UnityEngine;

public class LevelSystem
{
    private static readonly int[] experiencePerLevel = {0, 100, 200, 300, 400, 500};

    private int _level;
    private int _experience;

    public event Action ExperienceChanged;
    public event Action LevelChanged;

    public void AddExperience(int amount)
    {
        if (!IsMaxLevel())
        {
            _experience += amount;

            while (_experience >= GetExperienceToNextLevel(_level) && _experience >= GetExperienceToNextLevel(_level))
            {
                _experience -= GetExperienceToNextLevel(_level);
                _level++;

                LevelChanged?.Invoke();
            }

            ExperienceChanged?.Invoke();
        }
    }

    public int GetLevelNumber()
    {
        return _level;
    }

    public float GetExperienceNormalized()
    {
        if (IsMaxLevel())
            return 1f;
        else
            return (float) _experience / GetExperienceToNextLevel(_level);
    }

    public int GetExperience()
    {
        return _experience;
    }

    public int GetExperienceToNextLevel(int level)
    {
        if (level < experiencePerLevel.Length)
        {
            return experiencePerLevel[level];
        }
        else
        {
            Debug.Log("Level invalid: " + level);
            return 100;
        }
    }

    public bool IsMaxLevel(int level)
    {
        return level == experiencePerLevel.Length - 1;
    }

    private bool IsMaxLevel()
    {
        return IsMaxLevel(_level);
    }
}