using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shoes.Models;

public partial class ShoesContext : DbContext
{
    public ShoesContext()
    {
    }

    public ShoesContext(DbContextOptions<ShoesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Melek\\SQLEXPRESS;Database=Shoes;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId);

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriAd)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.UrunId).HasName("PK_Table_1");

            entity.ToTable("Urunler");

            entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Ozellik)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ResimAd).HasMaxLength(500);
            entity.Property(e => e.UrunAd)
                .HasMaxLength(600)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
