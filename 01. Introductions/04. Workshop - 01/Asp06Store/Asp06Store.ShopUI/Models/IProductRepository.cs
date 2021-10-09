namespace Asp06Store.ShopUI.Models
{
    public interface IProductRepository
    {
        PagedData<Product> GetAll(int pageNumber, int pageSize);
    }
}
