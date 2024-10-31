using System.Text.Json.Serialization;

namespace MyCompany.Communication.Response
{
    public class ResponseFornecedorJson
    {
        public int Id { get; set; }
        public bool Ativo { get; set; } = true;
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public string? Email { get; set; }
    }
}
