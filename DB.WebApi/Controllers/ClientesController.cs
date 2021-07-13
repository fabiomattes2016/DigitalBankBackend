using DB.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<Cliente>()
            {
                new Cliente
                {
                    Id = 1,
                    Nome = "Fábio",
                    Sobrenome = "Jesus da Silva Mattes",
                    DataNascimento = new DateTime(1982, 07, 29),
                    Cpf = "123.456.789-0",
                    DataCadastro = DateTime.Now,
                    Email = "fabiomattes2007@gmail.com",
                    Senha = "123456789",
                    Ativo = true
                }
            });
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
