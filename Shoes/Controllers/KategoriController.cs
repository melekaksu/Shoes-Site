using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shoes.Models;

namespace Shoes.Controllers
{
    public class KategoriController : Controller
    {
        ShoesContext db = new ShoesContext();

        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(Kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                db.Kategorilers.Add(kategoriler);
                db.SaveChanges();
                return RedirectToAction("KategoriList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult KategoriList()
        {
            var kategoriler = db.Kategorilers.ToList();
            return View(kategoriler);
        }
    }
}