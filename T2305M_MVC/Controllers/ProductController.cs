using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2305M_MVC.Entities;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2305M_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            Product product = await _context.Products
                .Where(p=>p.Id == id)
                .Include(p=>p.Category)
                .FirstAsync();// 1 object
            List<Product> relateds = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Id == product.Category.Id)
                .ToList();
            ViewBag.Relateds = relateds;
            return View(product);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
           // Code add product to session
            
            return null;
        }
    }
}

