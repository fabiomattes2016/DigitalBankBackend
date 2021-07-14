using DB.Core.Domain;
using DB.Data.Context;
using DB.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DigitalBankContext digitalBankContext;

        public ClienteRepository(DigitalBankContext digitalBankContext)
        {
            this.digitalBankContext = digitalBankContext;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await digitalBankContext.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await digitalBankContext.Clientes.FindAsync(id);
        }

        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            await digitalBankContext.AddAsync(cliente);
            await digitalBankContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsultado = await digitalBankContext.Clientes.FindAsync(cliente.Id);

            if (clienteConsultado == null)
            {
                return null;
            }

            digitalBankContext.Entry(clienteConsultado).CurrentValues.SetValues(cliente);
            await digitalBankContext.SaveChangesAsync();

            return clienteConsultado;
        }

        public async Task<(bool resultado, string message)> DeleteClienteAsync(int id)
        {

            var clienteConsultado = await digitalBankContext.Clientes.FindAsync(id);

            if (clienteConsultado != null)
            {
                digitalBankContext.Remove(clienteConsultado);
                await digitalBankContext.SaveChangesAsync();

                return (true, "Cliente excluído com sucesso");
            }

            return (false, "Cliente não encontrado");
        }
    }
}
