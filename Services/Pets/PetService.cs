using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;
using WebApplication1.Repositories.Pets;
using WebApplication1.Validations;

namespace WebApplication1.Services.Pets
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IPessoaService _pessoaService;

        public PetService(IPetRepository petRepository, IPessoaService pessoaService)
        {
            _petRepository = petRepository;
        }

        public async Task<Pet> CreateComPessoaAsync(Pet pet, Pessoa pessoa)
        {
            var novapessoa = await _pessoaService.Create(pessoa);
            pet.PessoaId = novapessoa.Id;
            return await CreateAsync(pet);
        }
        public async Task<Pet> CreateAsync(Pet pet)
        {
            pet.Id = Guid.NewGuid();
            Validar(pet);
            await _petRepository.Create(pet);
            return pet;
        }
        public Task<List<Pet>> List(Guid id, string nome, TipoPet? tipo, string raca, int? idade, Guid pessoaId)
        {
            return _petRepository.List(id, nome, tipo, raca, idade, pessoaId);
        }
        public Task Delete(Guid id)
        {
            return _petRepository.Delete(id);
        }
         public async Task<Pet> Update(Pet pet)
         {
            Validar(pet);
            await _petRepository.Update(pet);
            return pet;
         }
         public static void Validar(Pet pet)
         {
            var validator = new PetValidator();
            validator.ValidateAndThrow(pet);
         }        
    }
}
