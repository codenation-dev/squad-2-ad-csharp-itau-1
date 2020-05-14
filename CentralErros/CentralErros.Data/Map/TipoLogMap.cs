using CentralErros.Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralErros.Data.Map
{
    public class TipoLogMap : IEntityTypeConfiguration<TipoLog>
    {
        public void Configure(EntityTypeBuilder<TipoLog> builder)
        {
            builder.ToTable("TipoLog");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.HasMany<Log>(p => p.Logs)
                .WithOne(t => t.TipoLog)
                .HasForeignKey(t => t.IdTipoLog);
        }
    }
}
