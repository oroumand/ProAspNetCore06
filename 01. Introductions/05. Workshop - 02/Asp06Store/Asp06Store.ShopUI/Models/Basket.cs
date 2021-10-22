namespace Asp06Store.ShopUI.Models;

public class Basket
{
    private List<BasketItem> _items = new();

    public virtual void Add(Product product, int quantity)
    {
        var basketItem = _items.Where(c => c.Product.Id == product.Id).FirstOrDefault();
        if (basketItem != null)
        {
            basketItem.Quantity += quantity;
        }
        else
        {
            _items.Add(new BasketItem
            {
                Product = product,
                Quantity = quantity
            });
        }
    }

    public virtual void Remove(Product product) =>
        _items.RemoveAll(c => c.Product.Id == product.Id);

    public int TotalPrice() =>
        _items.Sum(c => c.Product.Price * c.Quantity);

    public virtual void Clear() => _items.Clear();
    
    public IEnumerable<BasketItem> Items => _items;
}

public class SessionBasket:Basket
{
    private  ISession _session;

    public static SessionBasket GetBasket(IServiceProvider service)
    {
        var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
        SessionBasket basket = session.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
        basket._session = session;

        return basket;
    }
    public override void Add(Product product, int quantity)
    {
        base.Add(product, quantity);
        _session.SetJson("Basket", this);
    }
    public override void Remove(Product product)
    {
        base.Remove(product);
        _session.SetJson("Basket", this);

    }
    public override void Clear()
    {
        base.Clear();
        _session.Remove("Basket");
    }
}
public class BasketItem
{

    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}

