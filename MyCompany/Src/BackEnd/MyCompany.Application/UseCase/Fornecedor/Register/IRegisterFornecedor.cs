using MyCompany.Communication.Request;
using MyCompany.Communication.Response;

namespace MyCompany.Application.UseCase.Fornecedor.Register
{
    public interface IRegisterFornecedor
    {
        public Task<ResponseFornecedorJson> Execute(RequestNewFornecedorJson request);
    }
}
