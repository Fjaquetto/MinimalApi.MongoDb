using MediatR;
using MinimalAPI.MongoDB.Domain.Core.Config.Query;

namespace MinimalAPI.MongoDB.Domain.Queries
{
    public class ObterPorIdClienteQuery : IRequest<QueryResponse>
    {
        public string Id { get; protected set; }

        public ObterPorIdClienteQuery(string id)
        {
            Id = id;
        }
    }
}
