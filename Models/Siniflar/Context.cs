﻿using System.Data.Entity;

namespace MvcWebTicariOtomasyon.Models.Siniflar

{
    //backend için yazılan tablolar için oluşturulan kısım
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<SatisHareketi> SatisHareketis { get; set; }
        public DbSet<Detay> Detays { get; set; }
        public DbSet<Yapilacak> Yapilacaks { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<mesaj> mesajs { get; set; }
    }
}
