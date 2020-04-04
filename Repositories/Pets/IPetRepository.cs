using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entidades.Pets;

namespace WebApplication1.Repositories.Pets
{
    public interface IPetRepository
    {
        Task Create(Pet pet);
        Task Delete(Guid Id);
        Task<List<Pet>> List(Guid id, string nome, TipoPet? tipo, string raca, int? idade, Guid pessoaId);
        Task Update(Pet pet);
    }
}
