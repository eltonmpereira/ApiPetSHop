using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;

namespace WebApplication1.Services
{
    public interface IPessoaService
    {
        Task<Pessoa> Create(Pessoa pessoa);
        Task<Pessoa> Update(Pessoa pessoa);
        Task<List<Pessoa>> List(Guid id, string nome, string sobreNome, string rg);
        Task Delete(Guid id);
    }
}