namespace Asp06Store.ShopUI.Controllers;

public class BasketController : Controller
{
    private readonly IProductRepository productRepository;
    private readonly Basket sessionBasket;

    public BasketController(IProductRepository productRepository, Basket sessionBasket)
    {
        this.productRepository = productRepository;
        this.sessionBasket = sessionBasket;
    }
    public IActionResult Index(string returnUrl)
    {
        BasketPageViewModel basketPageViewModel = new()
        {
            //Basket = GetBasket(),
            Basket = sessionBasket,
            ReturnUrl = returnUrl
        };

        return View(basketPageViewModel);
    }
    [HttpPost]
    public IActionResult AddToBasket(int productId, string returnUrl)
    {
        var product = productRepository.GetById(productId);
        //var basket = GetBasket();
        sessionBasket.Add(product, 1);
        //basket.Add(product, 1);
        //SaveBasket(basket);
        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }


    public IActionResult RemoveFromBasket(int productId, string returnUrl)
    {
        var product = productRepository.GetById(productId);
        //var basket = GetBasket();
        //basket.Remove(product);
        //SaveBasket(basket);
        sessionBasket.Remove(product);
        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }

    //private Basket GetBasket()
    //{
    //    return HttpContext.Session.GetJson<Basket>("Basket");
    //}

    //private void SaveBasket(Basket basket)
    //{
    //    HttpContext.Session.SetJson("Basket", basket);
    //}

}
