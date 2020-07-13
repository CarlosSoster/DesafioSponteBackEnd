using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SponteBackEnd.Models;

namespace SponteBackEnd.Data.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Altura).IsRequired();
            builder.Property(x => x.Largura).IsRequired();
            builder.Property(x => x.Comprimento).IsRequired();
            builder.Property(x => x.Peso).IsRequired();
            builder.Property(x => x.CodigoBarras).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.DataAquisicao).IsRequired();
        }
    }
}