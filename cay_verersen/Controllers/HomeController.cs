using cay_verersen.Contexts;
using cay_verersen.Models;
using cay_verersen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cay_verersen.Controllers
{
    public class HomeController : Controller
    {
        private readonly CayverersenDbContext _context;

        public HomeController(CayverersenDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Sliders = await _context.Sliders.ToListAsync();
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            var categories = await _context.Categories.ToListAsync();

            HomeViewModel homeViewModel = new()
            {
                Sliders = Sliders,
                Products = products,
                Categories = categories
            };

            return View(homeViewModel);
        }

        //public async Task<IActionResult> Index(int categoryId)
        //{
        //    var Sliders = await _context.Sliders.ToListAsync();
        //    var categories = await _context.Categories.ToListAsync();
        //    var products = await _context.Products
        //        .Include(p => p.CategoryId)
        //        .Where(p => p.CategoryId == categoryId)
        //        .ToListAsync();

        //    HomeViewModel homeViewModel = new HomeViewModel
        //    {
        //        Sliders = Sliders,
        //        Products = products,
        //        Categories = categories 
        //    };


        //    return View(homeViewModel);
        //}
    }
}
