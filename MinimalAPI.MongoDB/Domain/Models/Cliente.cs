using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MinimalAPI.MongoDB.Models
{
    public class Cliente
    {
        [BsonId]
        public string Id { get; set; } 
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public bool Ativo { get; set; }

        public Cliente() 
        {
        }

        public Cliente(string? nome, string? documento, bool ativo)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Documento = documento;
            Ativo = ativo;
        }
    }
}
