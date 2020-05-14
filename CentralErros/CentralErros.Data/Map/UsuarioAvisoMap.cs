using CentralErros.Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralErros.Data.Map
{
    public class UsuarioAvisoMap : IEntityTypeConfiguration<UsuarioAviso>
    {
        public void Configure(EntityTypeBuilder<UsuarioAviso> builder)
        {
            builder.ToTable("UsuarioAviso");

            builder.HasKey(t => new { t.IdUsuario, t.IdAviso });

            builder.HasOne(u => u.Usuario)
                .WithMany(ua => ua.UsuariosAvisos)
                .HasForeignKey(u => u.IdUsuario);

            builder.HasOne(u => u.Aviso)
                .WithMany(ua => ua.UsuariosAvisos)
                .HasForeignKey(u => u.IdAviso);

            builder.Property(x => x.Visualizado)
                 .HasColumnType("TINYINT");

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
