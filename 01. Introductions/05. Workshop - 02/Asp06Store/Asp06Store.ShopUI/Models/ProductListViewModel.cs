namespace Asp06Store.ShopUI.Models
{
    public class ProductListViewModel
    {
        public PagedData<Product> Data { get; set; }
        public string CurrentCategory { get; set; }
    }
}
