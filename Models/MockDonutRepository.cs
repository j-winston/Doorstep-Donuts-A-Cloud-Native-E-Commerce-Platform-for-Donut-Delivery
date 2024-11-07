namespace e_commerce.Models;

public class MockDonutRepository : IDonutRepository
{
    private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

    public IEnumerable<Donut> AllDonuts =>
        new List<Donut>
        {
            new Donut
            {
                DonutId = 0,
                Name = "Long John",
                ShortDescription = "Airy, light donut with real Hershey's chocolate frosting.",
                LongDescription = "A long-time favorite. This donut is just absolutely amazing. Try it for yourself and see!",
                Price = 3.5M,
                Category = _categoryRepository.AllCategories.ToList()[1],
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsDonutofTheDay = false
            },
            new Donut
            {
                DonutId = 1,
                Name = "Glazed Yeast",
                ShortDescription = "Classic airy yeast donut with a sweet glaze.",
                LongDescription = "A light and fluffy donut with a glossy glaze. Perfect for any time of day.",
                Price = 2.0M,
                Category = _categoryRepository.AllCategories.ToList()[1],
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsDonutofTheDay = false
            },
            new Donut
            {
                DonutId = 2,
                Name = "Chocolate Cake",
                ShortDescription = "Rich, dense chocolate cake donut with sprinkles.",
                LongDescription = "A decadent, chocolatey delight for those who love a rich, dense donut. Topped with colorful sprinkles!",
                Price = 2.5M,
                Category = _categoryRepository.AllCategories.ToList()[0],
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsDonutofTheDay = false

            },
            new Donut
            {
                DonutId = 3,
                Name = "Blueberry Crueller",
                ShortDescription = "Light and airy crueller with a blueberry glaze.",
                LongDescription = "An airy crueller with a unique twist. This blueberry glaze will have you craving more.",
                Price = 3.0M,
                Category = _categoryRepository.AllCategories.ToList()[2],
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsDonutofTheDay = false
            },
            new Donut
            {
                DonutId = 4,
                Name = "Maple Yeast",
                ShortDescription = "Fluffy yeast donut with a maple glaze.",
                LongDescription = "A Canadian favorite, this maple-glazed yeast donut is light and delicious. A must-try for donut lovers.",
                Price = 2.75M,
                Category = _categoryRepository.AllCategories.ToList()[2],
                ImageUrl = "",
                ImageThumbnailUrl = "",
                IsDonutofTheDay = false

            }
        };

    public Donut? GetDonutById(int donutId) => AllDonuts.FirstOrDefault(d => d.DonutId == donutId);
}

