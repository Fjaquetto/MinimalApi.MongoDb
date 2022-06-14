using MinimalAPI.MongoDB.Domain.Interfaces;
using MinimalAPI.MongoDB.Models;
using MongoDB.Driver;

namespace MinimalAPI.MongoDB.Data.Repository
{
    public class RepositoryClientes : Repository<Cliente>, IRepositoryClientes
    {
        public RepositoryClientes(IMongoDatabase db)
            : base(db) { }

        public Task<Cliente> AtualizarCliente(Cliente obj)
        {
            var filter = Builders<Cliente>.Filter.Where(x => x.Id == obj.Id);

            var updateDefBuilder = Builders<Cliente>.Update;
            var updateDef = updateDefBuilder.Combine(new UpdateDefinition<Cliente>[]
            {
                updateDefBuilder.Set(x => x.Id, obj.Id),
                updateDefBuilder.Set(x => x.Nome, obj.Nome),
                updateDefBuilder.Set(x => x.Documento, obj.Documento),
                updateDefBuilder.Set(x => x.Ativo, obj.Ativo)
            });
            _db.FindOneAndUpdateAsync(filter, updateDef);

            return _db.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
    }
}
