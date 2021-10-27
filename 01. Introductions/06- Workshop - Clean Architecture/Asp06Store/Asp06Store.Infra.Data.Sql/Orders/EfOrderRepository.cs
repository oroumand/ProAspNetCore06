namespace Asp06Store.ShopUI.Models;

public class EfOrderRepository : IOrderRepository
{
    private readonly StoreDbContext storeDbContext;

    public EfOrderRepository(StoreDbContext storeDbContext)
    {
        this.storeDbContext = storeDbContext;
    }
    public void Save(Order order)
    {
        storeDbContext.AttachRange(order.orderDetails.Select(d => d.Product));
        storeDbContext.Orders.Add(order);
        storeDbContext.SaveChanges();
    }
}