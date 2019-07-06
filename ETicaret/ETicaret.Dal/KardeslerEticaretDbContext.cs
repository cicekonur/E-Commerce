using ETicaret.Entities;
using ETicaret.Entities.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Dal
{
    public class KardeslerEticaretDbContext : DbContext
    {
        
        public KardeslerEticaretDbContext() : base("server=kardesler.database.windows.net; database=KardeslerEticaret;User Id=fortan;Password=Alaf9090;")
        {
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Configurations.Add(new UrunMapping());
            modelBuilder.Configurations.Add(new KategoriMapping());
            base.OnModelCreating(modelBuilder);
        }
    } 
    }

    

