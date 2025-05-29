using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.DataContext;


namespace PetShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext dbContext;

        public ProductController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

       public async Task<IActionResult> Details(int Id)
        {
            var product =await dbContext.Products.SingleOrDefaultAsync(x=>x.Id==Id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
