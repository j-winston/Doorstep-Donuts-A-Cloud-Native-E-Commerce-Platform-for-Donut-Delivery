namespace e_commerce.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private DoorStepDonutsDbContext? _doorStepDonutsDbContext;

        public CategoryRepository(DoorStepDonutsDbContext doorStepDonutsDbContext)
        {
            _doorStepDonutsDbContext = doorStepDonutsDbContext;
        }

        public IEnumerable<Category>? AllCategories =>
            _doorStepDonutsDbContext?.Categories?.OrderBy(p => p.CategoryName);

    }
}
