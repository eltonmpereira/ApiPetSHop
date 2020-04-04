using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entidades;

namespace WebApplication1.Repositories
{
    public interface IPessoaRepository
    {
        Task Create(Pessoa pessoa);
        Task Delete(Guid id);
        Task<List<Pessoa>> List(Guid id, string nome, string sobreNome, string rg);
        Task Update(Pessoa pessoa);
    }
}
