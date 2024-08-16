using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2305M_MVC.Entities;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2305M_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            Category category = _context.Categories.Find(id);
            List<Product> products = _context.Products
                    .Include(p => p.Category)
                    .Where(p => p.Category.Id == category.Id)
                    .ToList();
            ViewBag.category = category;
            return View(products);
        }
    }
}

