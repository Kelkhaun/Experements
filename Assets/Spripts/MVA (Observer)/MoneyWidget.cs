using TMPro;
using UnityEngine;

public class MoneyWidget : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _moneyText;

   public void SetupMoney(string text)
   {
      _moneyText.SetText(text);
   }

   public void UpdateMoney(string text)
   {
      _moneyText.SetText(text);
   }
}