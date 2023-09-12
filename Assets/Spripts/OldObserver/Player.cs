using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ISubject
{
    private List<IObserver> _observers = new();
    private int _health;

    private int GetHealth() => _health;

    private void Start()
    {
        Notify();
    }

    public void Attach(IObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        if (_observers.Contains(observer))
            _observers.Remove(observer);
    }

    private void Notify()
    {
        foreach (var observer in _observers)
            observer.HealthChanged();
    }
}