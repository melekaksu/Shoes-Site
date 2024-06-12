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
    public class IletisimController : Controller
    {
        ShoesContext db = new ShoesContext();
        public IActionResult Iletisim()
        {
            return View();
        }
    }
}