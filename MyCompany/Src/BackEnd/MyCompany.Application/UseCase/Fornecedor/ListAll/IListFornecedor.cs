using MyCompany.Communication.Response;

namespace MyCompany.Application.UseCase.Fornecedor.ListAll
{
    public interface IListFornecedor
    {
        Task<ResponseListFornecedoresJson> Execute();
    }
}
