using CentralErros.Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralErros.Data.Map
{
    public class AvisoMap : IEntityTypeConfiguration<Aviso>
    {
        public void Configure(EntityTypeBuilder<Aviso> builder)
        {
            builder.ToTable("Aviso");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(x => x.Data)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
