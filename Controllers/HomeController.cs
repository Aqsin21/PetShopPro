using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.DataContext;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
    public HomeController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     public async Task<IActionResult> Index()
        {
            var sliders = await _dbContext.Sliders.ToListAsync();
            var model = new HomeViewModel
            {
                Sliders = sliders
            };
            return View(model);
        }

       
    }
}
