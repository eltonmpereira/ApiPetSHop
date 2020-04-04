using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entidades.Pets;

namespace WebApplication1.Repositories.Pets
{
    public class PetRepository : IPetRepository
    {
        private readonly WebApiContext _context;
        public PetRepository(WebApiContext context)
        {
            _context = context;
        }

        public Task Create(Pet pet)
        {
            _context.Pet.Add(pet);
            return _context.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            var pet = new Pet { Id = id };
            _context.Pet.Attach(pet);
            _context.Pet.Remove(pet);
            return _context.SaveChangesAsync();
        }
        public Task<List<Guid>> ListPorPessoa(Guid id) =>
            _context.Pet.Where(x => x.PessoaId == id)
            .AsNoTracking()
            .Select(x => x.Id)
            .ToListAsync();
        public Task<List<Pet>> List(Guid id, string nome, TipoPet? tipo, string raca, int? idade, Guid pessoaId)
        {
            var pet = _context.Pet.AsQueryable();

            if (id != Guid.Empty && id != null)
                pet = pet.Where(x => x.Id == id);
            if (string.IsNullOrWhiteSpace(nome) == false)
                pet = pet.Where(x => x.Nome == nome);
            if (tipo != default)
                pet = pet.Where(x => x.Tipo == tipo);
            if (string.IsNullOrWhiteSpace(raca) == false)
                pet = pet.Where(x => x.Raca == raca);
            if (idade != default)
                pet = pet.Where(x => x.Idade == idade);
            if (pessoaId != Guid.Empty && pessoaId == default)
                pet = pet.Where(x => x.PessoaId == pessoaId);

            return pet.AsNoTracking().ToListAsync();
        }

        public Task Update(Pet pet)
        {
            _context.Update(pet);
            return _context.SaveChangesAsync();
        }
    }
}
