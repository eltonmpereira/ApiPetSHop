using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.Requests.Pets;
using WebApplication1.Dtos.Responses.Pets;
using WebApplication1.Entidades.Pets;
using WebApplication1.Services.Pets;
using WebApplication1.Services;
using WebApplication1.Dtos.Requests;
using WebApplication1.Entidades;
using WebApplication1.Dtos.Requests.PessoaPet;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
       
        public PetController(IPetService petService)
        {
            _petService = petService;
        }       
        
        [HttpPost("create")]
        public async Task<PetResponse> CreateAsync([FromBody] PetRequest petRequest)
        {
            var pet = await _petService.CreateAsync(petRequest as Pet);
            return new PetResponse
            {
                Id = pet.Id,
                Nome = pet.Nome,
                Tipo = pet.Tipo,
                Raca = pet.Raca,
                Idade = pet.Idade,
            };
        }
        
        [HttpGet("list")]
        public async Task<List<PetResponse>> List(Guid id, string nome, TipoPet? tipo, string raca, int? idade, Guid pessoaId)
        {
            var list = await _petService.List(id, nome, tipo, raca, idade, pessoaId);
            return list.Select(pet => new PetResponse
                {
                    Id = pet.Id,
                    Nome = pet.Nome,
                    Tipo = pet.Tipo,
                    Raca = pet.Raca,
                    Idade = pet.Idade,
                    PessoaId = pet.PessoaId,
                }).ToList();
        }

        [HttpDelete("delete/{id}")]
        public Task Delete(Guid id)
        {
           return _petService.Delete(id);
        }

        [HttpPost("update")]
        public async Task<PetResponse> Update([FromBody] PetRequest petRequest)
        {
            var pet = await _petService.Update(petRequest as Pet);
            return new PetResponse
            {
                Id = pet.Id,
                Nome = pet.Nome,
                Tipo = pet.Tipo,
                Raca = pet.Raca,
                Idade = pet.Idade,
            };
        }

    }
}