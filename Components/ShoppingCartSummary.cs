using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.ViewModels;

namespace e_commerce.Components;

public class ShoppingCartSummary : ViewComponent
{
    private readonly IShoppingCart _shoppingCart;

    public ShoppingCartSummary(IShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        if (items is not null)
        {
            _shoppingCart.ShoppingCartItems = items;
        }

        var viewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

        return View(viewModel);
    }
}
