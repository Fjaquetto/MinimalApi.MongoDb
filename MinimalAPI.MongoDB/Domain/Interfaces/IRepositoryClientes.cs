using MinimalAPI.MongoDB.Models;

namespace MinimalAPI.MongoDB.Domain.Interfaces
{
    public interface IRepositoryClientes : IRepository<Cliente>
    {
        Task<Cliente> AtualizarCliente(Cliente obj);
    }
}
