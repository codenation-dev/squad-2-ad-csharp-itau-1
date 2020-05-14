using CentralErros.Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralErros.Data.Map
{
    public class UsuarioAplicacaoMap : IEntityTypeConfiguration<UsuarioAplicacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioAplicacao> builder)
        {
            builder.ToTable("UsuarioAplicacao");

            builder.HasKey(t => new { t.IdUsuario, t.IdAplicacao });

            builder.HasOne(u => u.Usuario)
                .WithMany(ua => ua.UsuariosAplicacoes)
                .HasForeignKey(u => u.IdUsuario);

            builder.HasOne(u => u.Aplicacao)
                .WithMany(ua => ua.UsuariosAplicacoes)
                .HasForeignKey(u => u.IdAplicacao);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
