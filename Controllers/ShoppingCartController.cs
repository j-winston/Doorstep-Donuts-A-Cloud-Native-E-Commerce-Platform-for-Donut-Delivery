using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.ViewModels;

namespace e_commerce.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IDonutRepository _donutRepository;
    private readonly IShoppingCart _shoppingCart;

    public ShoppingCartController(IDonutRepository donutRepository, IShoppingCart shoppingCart)
    {
        _donutRepository = donutRepository;
        _shoppingCart = shoppingCart;
    }


    public ViewResult Index()
    {
        var items = _shoppingCart.GetShoppingCartItems();

        if (items is not null)
        {
            _shoppingCart.ShoppingCartItems = items;
        }

        var shoppingCartTotal = _shoppingCart.GetShoppingCartTotal();

        var viewModel = new ShoppingCartViewModel(_shoppingCart, shoppingCartTotal);

        return View(viewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int donutId)
    {
        var selectedDonut = _donutRepository?.AllDonuts?.FirstOrDefault(d => d.DonutId == donutId);

        if (selectedDonut is not null)
        {
            _shoppingCart.AddToCart(selectedDonut);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int donutId)
    {
        var selectedDonut = _donutRepository?.AllDonuts?.FirstOrDefault(d => d.DonutId == donutId);

        if (selectedDonut is not null)
        {
            _shoppingCart.RemoveFromCart(selectedDonut);
        }

        return RedirectToAction("Index");

    }


}
