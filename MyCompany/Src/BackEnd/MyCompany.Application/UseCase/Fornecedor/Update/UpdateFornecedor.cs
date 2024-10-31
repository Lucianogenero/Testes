using AutoMapper;
using MyCompany.Application.UseCase.Fornecedor.Register;
using MyCompany.Communication.Request;
using MyCompany.Communication.Response.ResourceMessagesException;
using MyCompany.Domain.Repository;
using MyCompany.Exceptions.ExceptionBase;

namespace MyCompany.Application.UseCase.Fornecedor.Update
{
    public class UpdateFornecedor : IUpdateFornecedor
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;

        public UpdateFornecedor(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task IUpdateFornecedor.Execute(RequestFornecedorJson request)
        {
            var validator = await new RegisterFornecedorValidator()
                                    .ValidateAsync(new RequestNewFornecedorJson { Nome = request.Nome, Cnpj = request.Cnpj, Email = request.Email});
            
            if(!await _repository.CheckIdExistsFornecedor(request.Id))
                validator.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty,ResourceMessageExceptions.FORNECEDOR_NOT_FOUND));

            if (!validator.IsValid)
            {
                throw new ErrorOnValidationException(validator.Errors.Select(err => err.ErrorMessage).ToList());
            }

            var fornecedor = _mapper.Map<Domain.Entities.Fornecedor>(request);
            await _repository.UpdateFornecedor(fornecedor);
        }
    }
}
