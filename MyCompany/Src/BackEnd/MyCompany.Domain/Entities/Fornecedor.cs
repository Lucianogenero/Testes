namespace MyCompany.Domain.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public bool Ativo { get; set; } = true;
        public string? Nome { get; set; } 
        public string? Cnpj { get; set; }
        public string? Email { get; set; } 
    }
}
