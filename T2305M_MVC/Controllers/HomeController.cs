using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using T2305M_MVC.Models;
using T2305M_MVC.Entities;
using System.Collections.Generic;
namespace T2305M_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly DataContext _context;

    // reflection
    public HomeController(ILogger<HomeController> logger,DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Category> categories = _context.Categories.ToList();
        List<Product> products = _context.Products.ToList();
        ViewData["Count"] = 10;
        ViewBag.categories = categories;
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    public IActionResult Hello()
    {
        return View();
    }
}

