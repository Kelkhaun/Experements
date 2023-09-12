using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class MoneyStorage : MonoBehaviour
{
    public int Money { get; private set; }

    public event Action<int> OnMoneyChanged;

    [Button]
    public void AddMoney(int money)
    {
        if (money <= 0)
            throw new Exception("Value must be greater than 0");
        
        Money += money;
        OnMoneyChanged?.Invoke(Money);
    }

    [Button]
    public void RemoveMoney(int money)
    {
        if (money <= 0)
            throw new Exception("Value must be greater than 0");

        int nextMoney = Money - money;
        Money = nextMoney <= 0 ? 0 : nextMoney;

        OnMoneyChanged?.Invoke(Money);
    }
}