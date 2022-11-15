using ControleEmpresa.Data.Contexts;
using ControleEmpresa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEmpresa.Data.Repositories
{
    public class ProfissionalRepository
    {
        public void Cadastrar(Profissional profissional)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Profissional.Add(profissional);
                sqlServerContext.SaveChanges();
            }
        }

        public void Editar(Profissional profissional)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(profissional).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }
   
        public void Apagar(Profissional profissional)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Remove(profissional);
                sqlServerContext.SaveChanges();
            }
        }
      
        public Profissional BuscarPorId(Guid idProfissional)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Profissional.FirstOrDefault(p => p.IdProfissional.Equals(idProfissional));
            }
        }

        public Profissional BuscarPorCpf(string cpf)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Profissional.FirstOrDefault(p => p.Cpf.Equals(cpf));
            }
        }

        public Profissional BuscarPorEmail(string email)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Profissional.FirstOrDefault(p => p.Email.Equals(email));
            }
        }

        public Profissional BuscarPorTelefone(string telefone)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Profissional.FirstOrDefault(p => p.Telefone.Equals(telefone));
            }
        }

        public List<Profissional> BuscarTodos()
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Profissional.OrderBy(p => p.Nome).ToList();
            }
        }
    }
}
