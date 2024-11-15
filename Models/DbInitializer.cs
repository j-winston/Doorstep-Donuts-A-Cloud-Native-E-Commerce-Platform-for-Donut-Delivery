namespace e_commerce.Models
{
    public static class DbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // get context
            DoorStepDonutsDbContext dbContext = applicationBuilder.ApplicationServices.CreateScope
                ().ServiceProvider.GetRequiredService<DoorStepDonutsDbContext>();



            // check if data is present
            // 
            if (dbContext.Categories != null && !dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(Categories.Select(c => c.Value));

            }

            // check if there are donuts if not add some 
            if (dbContext.Donuts != null && !dbContext.Donuts.Any())
            {
                dbContext.Donuts.AddRange(

                        // Add seed data here 
                        );

            }

        }




        private static Dictionary<string, Category>? _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new Dictionary<string, Category>
                    {

                        { "Cake Donuts", new Category {CategoryName = "Cake Donuts"}},
                        { "Yeast Donuts", new Category {CategoryName = "Yeast Donuts"}},
                        { "Crueller Donuts", new Category {CategoryName = "Crueller Donuts"}}
                    };

                }

                return _categories;
            }

        }
    }
}
