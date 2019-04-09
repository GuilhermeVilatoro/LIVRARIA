using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infra.Data.Mappings
{
    internal class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode();

            builder.Property(a => a.Sobrenome)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode();
        }
    }
}