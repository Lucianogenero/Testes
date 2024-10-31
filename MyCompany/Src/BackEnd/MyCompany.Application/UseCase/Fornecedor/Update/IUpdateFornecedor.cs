using MyCompany.Communication.Request;

namespace MyCompany.Application.UseCase.Fornecedor.Update
{
    public interface IUpdateFornecedor
    {
        Task Execute(RequestFornecedorJson request);
    }
}
