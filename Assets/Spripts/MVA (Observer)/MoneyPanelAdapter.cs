using System;
using UnityEngine;

public class MoneyPanelAdapter : MonoBehaviour
{
    [SerializeField] private MoneyStorage _moneyStorage;
    [SerializeField] private MoneyWidget _moneyWidget;

    private void OnEnable()
    {
        _moneyStorage.OnMoneyChanged += OnMoneyChanged;
    }
    
    private void OnDisable()
    {
        _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
    }

    private void Awake()
    {
        _moneyWidget.SetupMoney(0.ToString());
    }

    private void OnMoneyChanged(int money)
    {
        _moneyWidget.UpdateMoney(money.ToString());
    }
}