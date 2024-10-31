using MyCompany.Communication.Response;

namespace MyCompany.Application.UseCase.Fornecedor.GetForId
{
    public interface IGetFornecedorId
    {
        Task<ResponseFornecedorJson> Execute(int id);
    }
}
