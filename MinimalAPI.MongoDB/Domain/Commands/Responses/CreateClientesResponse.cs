namespace MinimalAPI.MongoDB.Domain.Commands.Responses
{
    public class CreateClientesResponse
    {
        public string Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public bool Ativo { get; set; }
        public CreateClientesResponse(string nome, string documento, bool ativo)
        {
            Nome = nome;
            Documento = documento;
            Ativo = ativo;
        }
    }
}
