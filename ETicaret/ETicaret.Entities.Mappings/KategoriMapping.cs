using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entities.Mappings
{
    public class KategoriMapping:EntityTypeConfiguration<Kategori>
    {
        public KategoriMapping()
        {
            ToTable("Kategoriler");
            HasKey(i => i.Id);
            Property(k => k.KategoriAdi).HasMaxLength(50).HasColumnType("varchar");
            HasOptional(k => k.Kategoriler).WithMany().HasForeignKey(k => k.UstKategori);
            
            HasMany(u => u.Urunler).WithRequired(k => k.Kategori).HasForeignKey(p => p.KategoriId).WillCascadeOnDelete(false);


        }

    }
}
