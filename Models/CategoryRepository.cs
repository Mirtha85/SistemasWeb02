using SistemasWeb01.Models;
namespace SistemasWeb01.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethesdaPieShopDbContext _bethesdaPieShopDbContext;

        public CategoryRepository(BethesdaPieShopDbContext bethesdaPieShopDbContext)
        {
            _bethesdaPieShopDbContext = bethesdaPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _bethesdaPieShopDbContext.Categories.OrderBy(p => p.CategoryName);

    }
}
