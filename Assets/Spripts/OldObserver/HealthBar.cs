using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IObserver
{
    [SerializeField] private Player _player;
    
    private List<Image> _hearts;

    private void OnEnable()
    {
        _player.Attach(this);
    }
    
    private void OnDisable()
    {
        _player.Detach(this);
    }

    public void UpdateUI(int health)
    {
      //  print("реагирует на изменение хп");
    }

    public void HealthChanged()
    {
        UpdateUI(20);
    }
}
