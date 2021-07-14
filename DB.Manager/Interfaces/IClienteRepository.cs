using DB.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.Manager.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> AddClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task<(bool resultado, string message)> DeleteClienteAsync(int id);
    }
}
