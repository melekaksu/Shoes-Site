using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shoes.Models;

namespace Shoes.Controllers;

public class HomeController : Controller
{
    ShoesContext db = new ShoesContext();

    public IActionResult Index()
    {
        return View();

    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Hakkimizda()
    {
        return View();
    }
}
