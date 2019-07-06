using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Entities.Mappings
{
    public class UrunMapping:EntityTypeConfiguration<Urun>
    {
        public UrunMapping()
        {
            ToTable("Urunler");

            HasKey(i => i.Id);
            Property(p => p.Aciklama).HasMaxLength(2000)
                .HasColumnType("varchar");
            Property(p => p.Fiyat).HasColumnType("money");
            Property(p => p.ResimYolu).HasColumnType("varchar");
            Property(p => p.EklemeTarihi).HasColumnType("date");
            Property(p => p.UrunAdi).HasColumnType("varchar").HasMaxLength(500).HasColumnOrder(1).IsRequired();

            HasRequired(k => k.Kategori).WithMany(u => u.Urunler).HasForeignKey(p => p.KategoriId).WillCascadeOnDelete(false);


        }
    }
}
