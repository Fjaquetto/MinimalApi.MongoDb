using MinimalAPI.MongoDB.Domain.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MinimalAPI.MongoDB.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _db;
        public Repository(IMongoDatabase db)
        {
            _db = db.GetCollection<T>(typeof(T).FullName);
        }

        public async Task Excluir(Expression<Func<T, bool>> predicate)
        {
            await _db.DeleteOneAsync(predicate);
        }

        public async Task Inserir(T obj)
        {
            await _db.InsertOneAsync(obj);
        }

        public async Task<T> ObterPorPredicado(Expression<Func<T, bool>> predicate)
        {
            var filter = Builders<T>.Filter.Where(predicate);
            return (await _db.FindAsync(filter)).FirstOrDefault();
        }

        public IQueryable<T> ObterTodos()
        {
            return _db.AsQueryable();
        }
    }
}
