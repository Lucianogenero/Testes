using MyCompany.Domain.Entities;

namespace MyCompany.Domain.Repository
{
    public interface IFornecedorRepository
    {
        Task Add(Fornecedor fornecedor);

        Task<bool> CheckCnpjAlreadyRegistered(string cnpj);

        Task<List<Fornecedor>> ListAllFornecedor();

        Task<Fornecedor?> GetFornecedorId(int id);

        Task DeleteFornecedor(int id);

        Task UpdateFornecedor(Fornecedor fornecedor);

        Task<bool> CheckIdExistsFornecedor(int id);
    }
}
