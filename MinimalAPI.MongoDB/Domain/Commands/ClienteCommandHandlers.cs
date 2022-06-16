using MediatR;
using MinimalAPI.MongoDB.Domain.Core.Config.Command;
using MinimalAPI.MongoDB.Domain.Interfaces.Service;
using MinimalAPI.MongoDB.Models;

namespace MinimalAPI.MongoDB.Domain.Commands
{
    public class ClienteCommandHandlers : CommandHandler, 
        IRequestHandler<CreateClienteCommand, CommandResponse>
    {
        private readonly IDataService _dataService;
        public ClienteCommandHandlers(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<CommandResponse> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Nome, request.Documento, request.Ativo);

            // Consolida as notificações

            // Cadastra
            var result = await _dataService.Clientes.Inserir(cliente);

            // Dispara o evento de cliente cadastrado

            // Retorna os dados       
            return CreateResponse(result, "Cliente criado com sucesso.");
        }
    }
}
