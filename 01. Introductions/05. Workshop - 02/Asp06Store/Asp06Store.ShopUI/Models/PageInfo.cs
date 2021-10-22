namespace Asp06Store.ShopUI.Models
{
    public class PageInfo
    {
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        
        public int PageNumber { get; set; }

        public int PageCount => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public class PagedData<T>
    {
        public List<T> Data { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
