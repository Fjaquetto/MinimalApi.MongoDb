using System.Linq.Expressions;

namespace MinimalAPI.MongoDB.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> ObterTodos();

        Task<T> ObterPorPredicado(Expression<Func<T, bool>> predicate);

        Task Inserir(T obj);

        Task Excluir(Expression<Func<T, bool>> predicate);
    }
}
