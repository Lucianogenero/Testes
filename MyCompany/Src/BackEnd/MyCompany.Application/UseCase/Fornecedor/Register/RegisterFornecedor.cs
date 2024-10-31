using AutoMapper;
using MyCompany.Communication.Request;
using MyCompany.Communication.Response;
using MyCompany.Communication.Response.ResourceMessagesException;
using MyCompany.Domain.Repository;
using MyCompany.Exceptions.ExceptionBase;

namespace MyCompany.Application.UseCase.Fornecedor.Register
{
    public class RegisterFornecedor : IRegisterFornecedor
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _autoMapper;

        public RegisterFornecedor(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _autoMapper = mapper;
        }

        public async Task<ResponseFornecedorJson> Execute(RequestNewFornecedorJson request)
        {
            await Validate(request);

            var fornecedor = _autoMapper.Map<Domain.Entities.Fornecedor>(request);
            await _repository.Add(fornecedor);
            var response = _autoMapper.Map<ResponseFornecedorJson>(fornecedor);

            return response;
        }

        public async Task Validate(RequestNewFornecedorJson request)
        {
            var validator = await new RegisterFornecedorValidator().ValidateAsync(request);
            var cnpjExists = await _repository.CheckCnpjAlreadyRegistered(request.Cnpj);

            if (cnpjExists)
                validator.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessageExceptions.CNPJ_ALREADY_EXISTS));

            if (!validator.IsValid)
            {
                throw new ErrorOnValidationException(validator.Errors.Select(err => err.ErrorMessage).ToList());
            }
        }

    }
}
