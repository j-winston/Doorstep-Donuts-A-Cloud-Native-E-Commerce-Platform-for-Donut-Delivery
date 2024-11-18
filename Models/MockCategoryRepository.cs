namespace e_commerce.Models;

public class MockCategoryRepository : ICategoryRepository
{
    public IEnumerable<Category> AllCategories =>
        new List<Category>
        {
            new Category{CategoryId = 1, CategoryName="Cake Donuts", Description="Cake based goodness"},

            new Category{CategoryId = 2, CategoryName="Yeast Donuts", Description="Pillows of deliciousness"},

            new Category{CategoryId = 3, CategoryName="Crueller Donuts",Description="Sweet, delicate airy texture"}

        };



}
