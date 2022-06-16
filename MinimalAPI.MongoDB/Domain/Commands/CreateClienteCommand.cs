using MediatR;
using MinimalAPI.MongoDB.Domain.Core.Config.Command;

namespace MinimalAPI.MongoDB.Domain.Commands
{
    public class CreateClienteCommand : IRequest<CommandResponse>
    {
        public string Id { get; protected set; }
        public string? Nome { get; protected set; }
        public string? Documento { get; protected set; }
        public bool Ativo { get; protected set; }

        public CreateClienteCommand(string nome, string documento, bool ativo)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Documento = documento;
            Ativo = ativo;
        }
    }
}
