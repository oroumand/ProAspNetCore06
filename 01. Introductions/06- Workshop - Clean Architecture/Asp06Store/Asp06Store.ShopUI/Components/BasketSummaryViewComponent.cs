namespace Asp06Store.ShopUI.Components
{
    public class BasketSummaryViewComponent:ViewComponent
    {
        private readonly Basket basket;

        public BasketSummaryViewComponent(Basket basket)
        {
            this.basket = basket;
        }
        public IViewComponentResult Invoke()
        {

            return View(basket);
        }
    }
}
