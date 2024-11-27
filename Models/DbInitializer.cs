namespace e_commerce.Models
{
    public static class DbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // Get Context
            DoorStepDonutsDbContext dbContext = applicationBuilder.ApplicationServices.CreateScope
                ().ServiceProvider.GetRequiredService<DoorStepDonutsDbContext>();

            // Seed data if necessary
            if (dbContext.Categories != null && !dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(new[]
                {
                         new Category {CategoryName = "Cake Donuts"},
                        new Category { CategoryName = "Yeast Donuts" },
                        new Category { CategoryName = "Crueller Donuts" }
                });

                dbContext.SaveChanges();
            }

            // Seed Donuts 
            if (dbContext.Categories != null && dbContext.Donuts != null && !dbContext.Donuts.Any())
            {
                dbContext.Donuts.AddRange(new List<Donut> {
        new Donut
        {

            Name = "Long John",
            ShortDescription = "Airy, light donut with real Hershey's chocolate frosting.",
            LongDescription = "A long-time favorite. This donut is just absolutely amazing. Try it for yourself and see!",
            Price = 3.5M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Yeast Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/long-john-small.jpg",
            IsDonutOfTheDay = false,
            IsDonutOfTheWeek = true
        },
        new Donut
        {

            Name = "Chocolate Glazed",
            ShortDescription = "Classic chocolate-glazed yeast donut.",
            LongDescription = "This chocolate-glazed yeast donut offers the perfect blend of soft texture and rich flavor.",
            Price = 2.5M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Yeast Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/choc-glazed-small.jpg",
            IsDonutOfTheDay = false,
            IsDonutOfTheWeek = true
        },
        new Donut
        {

            Name = "Vanilla Cake",
            ShortDescription = "Rich vanilla-flavored cake donut.",
            LongDescription = "This vanilla-flavored cake donut is dense, rich, and satisfying for any dessert lover.",
            Price = 2.75M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Cake Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/pink-sprinkles.jpg",
            IsDonutOfTheDay = false,
            IsDonutOfTheWeek = true
        },
        new Donut
        {

            Name = "Maple Bar",
            ShortDescription = "Yeast donut topped with maple frosting.",
            LongDescription = "Enjoy the sweet and savory taste of this maple-glazed yeast donut, perfect for any time of day.",
            Price = 3.0M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Yeast Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/maple-bar-small.jpg",
            IsDonutOfTheDay = false,
            IsDonutOfTheWeek = false
        },
        new Donut
        {

            Name = "Strawberry Sprinkle",
            ShortDescription = "Yeast donut with strawberry frosting and sprinkles.",
            LongDescription = "A crowd favorite! This yeast donut is topped with strawberry frosting and colorful sprinkles.",
            Price = 3.25M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Yeast Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/strawberry-sprinkles-small.jpg",
            IsDonutOfTheDay = false,
            IsDonutOfTheWeek = false
        },
        new Donut
        {

            Name = "Glazed Twist",
            ShortDescription = "A twisted yeast donut with a sweet glaze.",
            LongDescription = "This light, airy twisted yeast donut is coated with a perfect sweet glaze, a timeless classic.",
            Price = 2.25M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Yeast Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/glazed-twist-small.jpg",
            IsDonutOfTheDay = false,
            IsDonutOfTheWeek = false
        },
        new Donut
        {
      Name = "Blueberry Crueller",
            ShortDescription = "A light crueller donut with blueberry glaze.",
            LongDescription = "This light and airy crueller is topped with a delightful blueberry glaze, making it irresistible.",
            Price = 2.75M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Crueller Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/blueberry-crueller-small.jpg",
            IsDonutOfTheDay = true,
            IsDonutOfTheWeek = false
        },
        new Donut
        {

            Name = "Chocolate Cake",
            ShortDescription = "Rich chocolate cake donut with sprinkles.",
            LongDescription = "A dense and rich chocolate cake donut topped with colorful sprinkles for extra fun.",
            Price = 3.0M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Cake Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/chocolate-cake-small.jpg",
            IsDonutOfTheDay = false,
            IsDonutOfTheWeek = false
        },
        new Donut
        {

            Name = "Cinnamon Crueller",
            ShortDescription = "Crisp crueller donut with a cinnamon-sugar coating.",
            LongDescription = "This crispy crueller is dusted with cinnamon sugar, making it the perfect comfort food.",
            Price = 3.25M,
            Category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Crueller Donuts")??
                throw new InvalidOperationException("Category 'Yeast Donuts' does not exist in the database."),
            ImageUrl = "",
            ImageThumbnailUrl = "/images/cinnamon-crueller-small.jpg",
            IsDonutOfTheDay = false,
            IsDonutOfTheWeek = false
        }
    });

                dbContext.SaveChanges();
            }



        }
    }
}






