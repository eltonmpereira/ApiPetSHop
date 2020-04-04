using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos.Requests.Pets;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;

namespace WebApplication1.Dtos.Requests.PessoaPet
{
    public class PessoaPetRequest
    {
        public PessoaRequest Pessoa { get; set; }
        public PetRequest Pet { get; set; }
    }
   
}
