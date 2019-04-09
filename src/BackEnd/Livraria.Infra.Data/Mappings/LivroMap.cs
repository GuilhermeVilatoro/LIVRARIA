using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infra.Data.Mappings
{
    internal class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode();

            builder.Property(l => l.NumeroDePaginas)
               .IsRequired();

            builder.Property(l => l.Edicao)
                .IsRequired();

            builder.Property(l => l.Ano)
                .IsRequired();            

            builder.Property(l => l.Descricao)
                .HasMaxLength(4000);

            builder.HasOne(l => l.Autor)
                .WithMany()
                .HasForeignKey(l => l.AutorId);           
        }
    }
}