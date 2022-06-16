using MediatR;
using MinimalAPI.MongoDB.Domain.Commands.Requests;
using MinimalAPI.MongoDB.Domain.Commands.Responses;
using MinimalAPI.MongoDB.Domain.Interfaces;
using MinimalAPI.MongoDB.Domain.Interfaces.Service;
using MinimalAPI.MongoDB.Models;

namespace MinimalAPI.MongoDB.Domain.Handlers.ClienteHandlers
{
    public class ClienteHandlers : IRequestHandler<CreateClientesRequest, CreateClientesResponse>
    {
        private readonly IDataService _dataService;
        public ClienteHandlers(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<CreateClientesResponse> Handle(CreateClientesRequest request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Nome, request.Documento, request.Ativo);

            // Consolida as notificações

            // Cadastra
            var result = await _dataService.Clientes.Inserir(cliente);

            // Dispara o evento de cliente cadastrado

            // Retorna os dados       

            return new CreateClientesResponse(result.Nome, result.Documento, result.Ativo);
        }
    }
}
