namespace e_commerce;
using e_commerce.Models;

public class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }
    public Donut Donut { get; set; } = default!;
    public int Amount { get; set; }
    public string? ShoppingCartId { get; set; }


}
