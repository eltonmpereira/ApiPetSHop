using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.Requests;
using WebApplication1.Dtos.Responses;
using WebApplication1.Entidades;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }
        [HttpPost("create")]
        public async Task<PessoaResponse> Create([FromBody] PessoaRequest pessoaRequest)
        {
            var pessoa = await _pessoaService.Create(pessoaRequest as Pessoa);
            return new PessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Rg = pessoa.Rg,
                Idade = pessoa.Idade,
            };
        }

        [HttpPost("update")]
        public async Task<PessoaResponse> Update([FromBody] PessoaRequest pessoaRequest)
        {
            var pessoa = await _pessoaService.Update(pessoaRequest as Pessoa);
            return new PessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Rg = pessoa.Rg,
                Idade = pessoa.Idade,
            };
        }

        [HttpPost("updatelist")]
        public async Task<IEnumerable<PessoaResponse>> UpdateList([FromBody] IEnumerable<PessoaRequest> pessoasRequest)
        {
            foreach(var pessoaRequest in pessoasRequest)
                await _pessoaService.Update(pessoaRequest as Pessoa);

            return pessoasRequest.Select(pessoa => new PessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Rg = pessoa.Rg,
                Idade = pessoa.Idade,
            }).ToList();
        }

        [HttpGet("list")]
        public async Task<IEnumerable<PessoaResponse>> List(Guid id, string nome, string sobreNome, string rg)
        {
            var list = await _pessoaService.List(id, nome, sobreNome, rg);
               return list.Select(pessoa => new PessoaResponse
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Rg = pessoa.Rg,
                    Idade = pessoa.Idade,
                }).ToList();
        }

        [HttpDelete("delete/{id}")]
        public Task Delete(Guid id)
        {
            _pessoaService.Delete(id);
            return _pessoaService.Delete(id);
        }

    }
}
