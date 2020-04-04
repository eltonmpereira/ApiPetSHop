using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.Requests.PessoaPet;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;
using WebApplication1.Services.Pets;

namespace WebApplication1.Controllers.PessoaPet
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaPetController : ControllerBase
    {
        //private readonly IpessoaService ipessoaService;
        private readonly IPetService _petService;
        public PessoaPetController(IPetService petService)
        {
            _petService = petService;
        }
      
        [HttpPost("create")]
        public Task<Pet> Create([FromBody] PessoaPetRequest pessoaPetRequest) =>
             _petService.CreateComPessoaAsync(pessoaPetRequest.Pet as Pet, pessoaPetRequest.Pessoa as Pessoa);

        [HttpDelete("delete/{id}")]
        public Task Delete(Guid id)
        {
            return _petService.Delete(id);
        }

    }
}