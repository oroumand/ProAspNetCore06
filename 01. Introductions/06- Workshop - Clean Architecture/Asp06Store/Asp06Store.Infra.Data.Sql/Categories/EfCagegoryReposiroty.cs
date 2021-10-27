namespace Asp06Store.ShopUI.Models;

public class EfCagegoryReposiroty : ICategoryRepository
{
    private readonly StoreDbContext storeDbContext;

    public EfCagegoryReposiroty(StoreDbContext storeDbContext)
    {
        this.storeDbContext = storeDbContext;
    }
    public List<string> GetAllCategories() =>
       storeDbContext.Categories.Select(c => c.Name).ToList();
}
