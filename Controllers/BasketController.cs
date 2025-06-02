using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShop.Models; 
using NuGet.Protocol.Plugins;
using PetShop.DataContext;

namespace PetShop.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _dbContext;
        private const string BasketCookieKey = "Basket";

        public BasketController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddToBasket(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            var basket = GetBasket();
             var existBasketItem = basket.Find(x=>x.ProductId== id);
            if (existBasketItem == null)
            {
                basket.Add(new BasketItem { ProductId=id ,Quantity =1});
            }

            
            else
            {
                existBasketItem.Quantity++;
            }
            var basketJson = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", basketJson, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddHours(1)
            });
            return  RedirectToAction("Index", "Home");
        }


        private List<BasketItem> GetBasket()
        {
            var basket = Request.Cookies[BasketCookieKey];
            if (string.IsNullOrEmpty(basket))
            {
                return new List<BasketItem>();
            }

            try
            {
                var basketItems = JsonConvert.DeserializeObject<List<BasketItem>>(basket);
                return basketItems ?? new List<BasketItem>();
            }
            catch
            {
                // Bozuk cookie varsa otomatik sıfırla
                Response.Cookies.Delete("Basket");
                return new List<BasketItem>();
            }
        }


        public IActionResult ClearBasket()
        {
            Response.Cookies.Delete("Basket");
            return RedirectToAction("Index", "Home");
        }
    }
}
