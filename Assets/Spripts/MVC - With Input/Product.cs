using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Products/New Product", fileName = "Product", order = 51)]
public sealed class Product : ScriptableObject
{
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}