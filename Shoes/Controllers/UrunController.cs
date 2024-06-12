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
    public class UrunController : Controller
    {
        ShoesContext db = new ShoesContext();

        public IActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urunler urun)
        {
            if (ModelState.IsValid)
            {
                db.Urunlers.Add(urun);
                db.SaveChanges();
                return RedirectToAction("TumUrunler");
            }
            return View(urun);
        }

        public IActionResult UrunListe(int kategoriId)
        {
            var urunler = db.Urunlers.Where(u => u.KategoriId == kategoriId).ToList();
            var kategori = db.Kategorilers.FirstOrDefault(k => k.KategoriId == kategoriId);
            ViewBag.KategoriAdi = kategori != null ? kategori.KategoriAd : "Kategori Bulunamadı";
            return View(urunler);
        }

        public IActionResult TumUrunler()
        {
            var urunler = db.Urunlers.ToList();
            ViewBag.KategoriAdi = "Tüm Ürünler";
            return View(urunler);
        }

        public IActionResult Detay(int id)
        {
            var urun = db.Urunlers.FirstOrDefault(u => u.UrunId == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        public IActionResult Sil(int id)
        {
            var urun = db.Urunlers.FirstOrDefault(u => u.UrunId == id);
            if (urun == null)
            {
                return NotFound();
            }

            db.Urunlers.Remove(urun);
            db.SaveChanges();

            return RedirectToAction("TumUrunler");
        }

        public IActionResult Guncelle(int id)
        {
            var urun = db.Urunlers.FirstOrDefault(u => u.UrunId == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        [HttpPost]
        public IActionResult Guncelle(Urunler urun)
        {
            if (ModelState.IsValid)
            {
                db.Urunlers.Update(urun);
                db.SaveChanges();
                return RedirectToAction("TumUrunler");
            }
            return View(urun);
        }
        public IActionResult Ara(string urunAdi)
        {
            var urunler = db.Urunlers.Where(u => u.UrunAd.Contains(urunAdi)).ToList();
            return View("Ara", urunler);
        }
    }
}