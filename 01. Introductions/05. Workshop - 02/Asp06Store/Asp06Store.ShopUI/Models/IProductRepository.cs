namespace Asp06Store.ShopUI.Models;

public interface IProductRepository
{
    PagedData<Product> GetAll(int pageNumber, int pageSize, string category);
    List<string> GetAllCategories();
    Product GetById(int id);
}

