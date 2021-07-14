using DB.Core.Domain;
using DB.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager clienteManager;

        public ClientesController(IClienteManager clienteManager)
        {
            this.clienteManager = clienteManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await clienteManager.GetClientesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await clienteManager.GetClienteAsync(id);

            if(cliente != null)
            {
                return Ok(cliente);
            }
            else
            {
                var message = new
                {
                    Status = 404,
                    Mensagem = "Cliente não encontrado"
                };

                return NotFound(message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            var clienteInserido = await clienteManager.AddClienteAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Cliente cliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(cliente);

            if (clienteAtualizado != null)
            {
                return Ok(clienteAtualizado);
            }
            else
            {
                var message = new
                {
                    Status = 404,
                    Mensagem = "Cliente não encontrado"
                };

                return NotFound(message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var retorno = await clienteManager.DeleteClienteAsync(id);

            if (retorno.resultado)
            {
                var sucesso = new
                {
                    status = 204,
                    message = retorno.message
                };

                return Ok(sucesso);
            }
            else
            {
                var falha = new
                {
                    status = 404,
                    message = retorno.message
                };

                return NotFound(falha);
            }
        }
    }
}
