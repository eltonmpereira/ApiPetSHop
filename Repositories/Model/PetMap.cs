using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entidades.Pets;

namespace WebApplication1.Repositories.Model
{
    public class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pet")
                .HasKey(x => x.Id);
            builder.Property(x => x.PessoaId)
               .HasColumnName("IdPessoa");
            builder.Property(x => x.Tipo)
                .HasConversion<string>();
        }
    }
}
