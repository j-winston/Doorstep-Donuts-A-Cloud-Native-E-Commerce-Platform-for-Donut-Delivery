namespace e_commerce.Models;

public interface IShoppingCart
{
    void AddToCart(Donut donut);
    int RemoveFromCart(Donut donut);
    void ClearCart();
    decimal GetShoppingCartTotal();
    List<ShoppingCartItem> ShoppingCartItems { get; set; }
}
