using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelSystemTester : MonoBehaviour
{
    [FormerlySerializedAs("_levelWindow")] [SerializeField] private LevelView levelView;
    
    private LevelSystem _levelSystem;
    private AnimatedLevelSystem _animatedLevelSystem;
    
    public void Awake()
    {
        _levelSystem = new LevelSystem();
        _animatedLevelSystem = new AnimatedLevelSystem(_levelSystem);
        levelView.SetLevelSystem(_animatedLevelSystem);
    }

    private void Update()
    {
        _animatedLevelSystem.Update();
    }

    [Button]
    public void AddExperience(int amount)
    {
        _levelSystem.AddExperience(amount);
    }
}