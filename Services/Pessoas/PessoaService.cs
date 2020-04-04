using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Pets;
using WebApplication1.Validations;

namespace WebApplication1.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPetRepository petRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> Create(Pessoa pessoa)
        {
            Validar(pessoa);
            pessoa.Id = Guid.NewGuid();
            await _pessoaRepository.Create(pessoa);
            return pessoa;           
            
        }

        public Task <List<Pessoa>> List(Guid id, string nome, string sobreNome, string rg)
        {
            return _pessoaRepository.List(id, nome, sobreNome, rg);
        }

        public Task Delete(Guid id)
        {
           
           return _pessoaRepository.Delete(id);
        }

        public async Task<Pessoa> Update(Pessoa pessoa)
        {
            Validar(pessoa);
            await _pessoaRepository.Update(pessoa);
            return pessoa;
        }

        public static void Validar(Pessoa pessoa)
        {
            var validator = new PessoaValidator();
            validator.ValidateAndThrow(pessoa);
        }
    }
}
