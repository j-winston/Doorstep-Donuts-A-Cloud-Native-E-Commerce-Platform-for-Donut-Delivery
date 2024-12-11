namespace e_commerce.Models;

public class ShoppingCart : IShoppingCart
{
    // Used to access database functionality 
    private readonly DoorStepDonutsDbContext _dbContext;

    public string? ShoppingCartId { get; set; }

    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

    private ShoppingCart(DoorStepDonutsDbContext dbContext)
    {
        _dbContext = dbContext;

    }

    // Return a fully created shopping cart
    public static ShoppingCart GetCart(IServiceProvider services)
    {
        // Get session through di system 
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

        // Get access to the db context
        DoorStepDonutsDbContext context = services.GetService<DoorStepDonutsDbContext>() ?? throw new Exception("Error initializing");

        // Get CartId if it exists, otherwise create a new one 
        string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

        session?.SetString("CartId", cartId);


        return new ShoppingCart(context) { ShoppingCartId = cartId };

    }


    public void AddToCart(Donut donut)
    {

        // Query the database table, ShoppingCartItems for a matching donut
        var shoppingCartItem = _dbContext?.ShoppingCartItems?.SingleOrDefault(
                s => s.Donut.DonutId == donut.DonutId && s.ShoppingCartId ==
                ShoppingCartId);

        // If its not found in the cart, let's create a cart entry 
        if (shoppingCartItem == null)
        {
            var donutItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Donut = donut,
                Amount = 1,
            };

            _dbContext?.ShoppingCartItems?.Add(donutItem);
        }

        else
        {
            // If its already in the cart, add another 
            shoppingCartItem.Amount++;
        }

        // Save changes, regardless
        _dbContext?.SaveChanges();
    }


    public int RemoveFromCart(Donut donut)
    {
        // See if its in the cart
        var shoppingCartItem = _dbContext?.ShoppingCartItems?.SingleOrDefault(
                s => s.Donut.DonutId == donut.DonutId && s.ShoppingCartId == ShoppingCartId
                );

        // Used to return the number of remaining donuts in the cart
        var localAmount = 0;

        // Check if a donut was returned from the cart
        if (shoppingCartItem != null)
        {
            // If there's at least more than one, reduce by one
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }

            // If there's one or less, remove it entirely 
            else
            {
                _dbContext?.Remove(shoppingCartItem);

            }

        }

        _dbContext?.SaveChanges();

        // Return the remaining number of items in the cart
        return localAmount;

    }

    public List<ShoppingCartItem>? GetShoppingCartItems()
    {
        return ShoppingCartItems ??= _dbContext.ShoppingCartItems.Where(c =>
                c.ShoppingCartId == ShoppingCartId).Include(s => s.Donut).ToList();

    }
    public void ClearCart()
    {


    }

    public decimal GetShoppingCartTotal()
    {
        return 2.2m;

    }





}
