using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;

namespace WebApplication1.Services.Pets
{
    public interface IPetService
    {
        Task<Pet> CreateComPessoaAsync(Pet pet, Pessoa pessoa);
        Task<Pet> CreateAsync(Pet pet);
        Task<List<Pet>> List(Guid id, string nome, TipoPet? tipo, string raca, int? idade, Guid pessoaId);
        Task Delete(Guid id);
        Task <Pet> Update(Pet pet);
       
    }
}
