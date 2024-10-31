using MyCompany.Communication.Response.ResourceMessagesException;
using MyCompany.Communication.Response.ResponseErrors;
using MyCompany.Domain.Repository;
using MyCompany.Exceptions.ExceptionBase;

namespace MyCompany.Application.UseCase.Fornecedor.Delete
{
    public class DeleteFornecedor : IDeleteFornecedor
    {
        private readonly IFornecedorRepository _repository;

        public DeleteFornecedor(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        async Task IDeleteFornecedor.Execute(int Id)
        {
            var validator = await _repository.CheckIdExistsFornecedor(Id);
            if (!validator)
            {
                throw new ErrorOnValidationException(new ResponseErrorJson(ResourceMessageExceptions.FORNECEDOR_NOT_FOUND).Errors );
            }
            await _repository.DeleteFornecedor(Id);
        }
    }
}
