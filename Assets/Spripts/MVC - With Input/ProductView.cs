using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ProductView : MonoBehaviour
{
    private TextMeshProUGUI _title;
    private TextMeshProUGUI _description;
    private TextMeshProUGUI _price;
    private Image _icon;
    private Button _buyButton;

    public Button BuyButton => _buyButton;

    public void SetTitle(string title)
    {
        _title.SetText(title);
    }

    public void SetDescription(string description)
    {
        _description.SetText(description);
    }

    public void SetIcon(Sprite image)
    {
        _icon.sprite = image;
    }

    public void SetPrice(string price)
    {
        _price.SetText(price);
    }
}