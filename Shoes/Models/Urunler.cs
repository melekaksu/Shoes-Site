using System;
using System.Collections.Generic;

namespace Shoes.Models;

public partial class Urunler
{
    public int UrunId { get; set; }

    public int? KategoriId { get; set; }

    public decimal? Fiyat { get; set; }

    public string? ResimAd { get; set; }

    public string? Ozellik { get; set; }

    public string? UrunAd { get; set; }
}
