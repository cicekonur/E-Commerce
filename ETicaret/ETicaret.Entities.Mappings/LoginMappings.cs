using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace ETicaret.Entities.Mappings
{
    public class LoginMappings : EntityTypeConfiguration<Login>
    {
        public LoginMappings()
        {
            ToTable("Login");
            HasKey(i => i.Id);
            Property(l => l.EMail).HasMaxLength(50).HasColumnType("varchar");
            Property(l => l.Sifre).HasMaxLength(12).HasColumnType("varchar");
            Property(l => l.Yetki).IsRequired();
            Property(l => l.KayitTarihi).IsOptional();

            HasMany(u => u.Urunler).WithMany(l => l.Login).Map(u => u.MapLeftKey("Id")).Map(l => l.MapRightKey("Id").ToTable("Sepet"));

        }

    }
}
