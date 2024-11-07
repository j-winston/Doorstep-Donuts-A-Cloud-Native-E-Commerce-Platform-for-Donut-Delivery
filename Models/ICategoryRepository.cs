namespace e_commerce.Models;

public interface ICategoryRepository
{
    IEnumerable<Category> AllCategories { get; }


}
