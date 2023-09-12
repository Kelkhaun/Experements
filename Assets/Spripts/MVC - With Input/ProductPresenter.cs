using UnityEngine;

public sealed class ProductPresenter : MonoBehaviour
{
    private readonly ProductView _view;
    private readonly Product _product;
    private readonly ProductBuyer _productBuyer;

    public ProductPresenter(Product product, ProductView view, ProductBuyer buyerManager)
    {
        _product = product;
        _view = view;
        _productBuyer = buyerManager;
    }

    public void Enable()
    {
        _view.SetTitle(_product.Title);
        _view.SetDescription(_product.Title);
        _view.SetIcon(_product.Icon);

        // _view.
    }
}

public sealed class ProductBuyer
{
    [SerializeField] private Product _product;

    public void Show(object args)
    {
        // foreach (var presenter in _presenters)
        // {
        //     presenter.Disable();
        // }
    }

    public void Hide()
    {
        // foreach (var presenter in _presenters)
        // {
        //     presenter.Disable();
        // }
    }

    public void CreateProducts()
    {
        // var products = _catalog.products;
        //
        // foreach (var product in _products)
        // {
        //     var view = Instantiate(_viewPrefab, _viewContainer);
        //     var presenter = new ProductPresenter(product, view, _productBuyer, _moneyStorage)
        //     presenters.Add(presenter);
    }
}