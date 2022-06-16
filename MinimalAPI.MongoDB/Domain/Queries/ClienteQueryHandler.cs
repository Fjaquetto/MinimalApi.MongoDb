using MediatR;
using MinimalAPI.MongoDB.Domain.Core.Config.Query;
using MinimalAPI.MongoDB.Domain.Interfaces.Service;

namespace MinimalAPI.MongoDB.Domain.Queries
{
    public class ClienteQueryHandler : QueryHandler,
        IRequestHandler<ObterPorIdClienteQuery, QueryResponse>
    {
        private readonly IDataService _dataService;
        public ClienteQueryHandler(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<QueryResponse> Handle(ObterPorIdClienteQuery request, CancellationToken cancellationToken)
        {

            // Consolida as notificações

            // Cadastra
            var result = await _dataService.Clientes.ObterPorPredicado(x=>x.Id == request.Id);

            // Dispara o evento de cliente cadastrado

            // Retorna os dados       
            return OkResponse(result, "Cliente encontrado com sucesso.");
        }
    }
}
