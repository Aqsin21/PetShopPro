using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShop.DataContext;
using PetShop.Models;

namespace PetShop.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {

        private readonly AppDbContext _dbContext;

        public BasketViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public IViewComponentResult Invoke()
        {
                var basket =Request.Cookies["Basket"];
                if (string.IsNullOrEmpty(basket))
                {
                    return Content("0");
                }


 
                var basketItems=JsonConvert.DeserializeObject<List<BasketItem>>(basket);

            var cart = new CartViewModel();
            var cartItemList= new List<CartItemViewModel>();
            foreach (var item in basketItems)
            {
                var product = _dbContext.Products.Find(item.ProductId);
                if (product ==null)
                {
                    continue; // Skip if product not found
                }
                cartItemList.Add(new CartItemViewModel
                {
                    ProductName = product.Name,
                    Decription = product.Name,
                    Price = product.Price,
                    Quantity = item.Quantity
                });

            }

            cart.Items = cartItemList;
            cart.Quanity = cartItemList.Sum(x => x.Quantity);
            cart.Total =cartItemList.Sum(x=>x.Quantity * x.Price); // Assuming ProductId is the price, which is incorrect, but for demonstration purposes



            return View(cart);
        }
    }
}