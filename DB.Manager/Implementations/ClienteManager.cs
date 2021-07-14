using DB.Core.Domain;
using DB.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Manager.Implementations
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteManager(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }
        
        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await clienteRepository.GetClienteAsync(id);
        }

        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            return await clienteRepository.AddClienteAsync(cliente);
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            return await clienteRepository.UpdateClienteAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await clienteRepository.DeleteClienteAsync(id);
        }
    }
}
