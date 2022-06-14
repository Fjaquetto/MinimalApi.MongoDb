using MinimalAPI.MongoDB.Data.Contexts;
using MinimalAPI.MongoDB.Data.Repository;
using MinimalAPI.MongoDB.Domain.Interfaces;
using MinimalAPI.MongoDB.Domain.Interfaces.Service;

namespace MinimalAPI.MongoDB.Data.Service
{
    public class DataService : IDataService
    {
        private readonly MongoContext _dbContext;

        public DataService(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepositoryClientes Clientes => new RepositoryClientes(_dbContext.Database);
    }
}
