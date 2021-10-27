using Microsoft.AspNetCore.Mvc;

namespace Asp06Store.ShopUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly Basket basket;

        public OrderController(IOrderRepository orderRepository, Basket basket)
        {
            this.orderRepository = orderRepository;
            this.basket = basket;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            if (!basket.Items.Any())
            {
                ModelState.AddModelError("", "ther is not any item in the basket");
            }
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City
                };
                foreach (var item in basket.Items)
                {
                    order.orderDetails.Add(new OrderDetail
                    {
                        Product = item.Product,
                        Quantity = item.Quantity,
                    });
                }
                orderRepository.Save(order);
                basket.Clear();
                return RedirectToAction("Compelete");
            }
            return View(model);
        }

        public IActionResult Compelete()
        {
            return View();
        }

    }
}
