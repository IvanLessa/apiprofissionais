using ControleEmpresa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEmpresa.Data.Mappings
{
    public class ProfissionalMap : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("PROFISSIONAL");

            builder.HasKey(u => u.IdProfissional);

            builder.Property(u => u.IdProfissional)
                .HasColumnName("IDPROFISSIONAL")
                .IsRequired();

            builder.Property(u => u.Nome)
               .HasColumnName("NOME")
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(u => u.Email)
              .HasColumnName("EMAIL")
              .HasMaxLength(100)
              .IsRequired();

            builder.HasIndex(u => u.Email)
               .IsUnique();

            builder.Property(u => u.Cpf)
               .HasColumnName("CPF")
               .HasMaxLength(11)
               .IsRequired();

            builder.HasIndex(u => u.Cpf)
               .IsUnique();

            builder.Property(u => u.Telefone)
              .HasColumnName("TELEFONE")
              .HasMaxLength(20)
              .IsRequired();

            builder.HasIndex(u => u.Telefone)
               .IsUnique();

            builder.Property(u => u.DataCadastro)
              .HasColumnName("DATACADASTRO")
              .IsRequired();
        }
    }
}
