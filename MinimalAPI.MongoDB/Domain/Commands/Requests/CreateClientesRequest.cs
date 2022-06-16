using MediatR;
using MinimalAPI.MongoDB.Domain.Commands.Responses;

namespace MinimalAPI.MongoDB.Domain.Commands.Requests
{
    public class CreateClientesRequest : IRequest<CreateClientesResponse>
    {
        public string Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public bool Ativo { get; set; }

        public CreateClientesRequest(string nome, string documento, bool ativo)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Documento = documento;
            Ativo = ativo;
        }
    }
}
