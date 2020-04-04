using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;

namespace WebApplication1.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly WebApiContext _context;
        

        public PessoaRepository(WebApiContext context)
        {
            _context = context;
        }

        public Task Create(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            return _context.SaveChangesAsync();            
        }

        public Task Delete(Guid id)
        {
            var pessoa = new Pessoa { Id = id };
            _context.Pessoa.Attach(pessoa);
            _context.Pessoa.Remove(pessoa);
            return _context.SaveChangesAsync();
        }

            public Task<List<Pessoa>> List(Guid id, string nome, string sobreNome, string rg)
        {
            var pessoas = _context.Pessoa.AsQueryable();

            if (id != Guid.Empty && id != null)
                pessoas = pessoas.Where(x => x.Id == id);
            if (string.IsNullOrWhiteSpace(nome) == false)
                pessoas = pessoas.Where(x => x.Nome == nome);
            if (string.IsNullOrWhiteSpace(sobreNome) == false)
                pessoas = pessoas.Where(x => x.Sobrenome == sobreNome);
            if (string.IsNullOrWhiteSpace(rg) == false)
                pessoas = pessoas.Where(x => x.Rg == rg);

            return pessoas.AsNoTracking().ToListAsync();
        }
        
        public Task Update(Pessoa pessoa)
        {
        _context.Update(pessoa);
        return _context.SaveChangesAsync();
        }           
        
    }
}
