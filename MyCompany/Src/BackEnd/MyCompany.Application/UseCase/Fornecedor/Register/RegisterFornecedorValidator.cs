using FluentValidation;
using MyCompany.Communication.Request;
using MyCompany.Communication.Response.ResourceMessagesException;
namespace MyCompany.Application.UseCase.Fornecedor.Register
{
    public class RegisterFornecedorValidator : AbstractValidator<RequestNewFornecedorJson>
    {
        public RegisterFornecedorValidator()
        {
            RuleFor(req => req.Nome).NotEmpty().WithMessage(ResourceMessageExceptions.NAME_EMPTY)
                                    .MinimumLength(3).WithMessage(ResourceMessageExceptions.NAME_MINIMUM_SIZE)
                                    .MaximumLength(60).WithMessage(ResourceMessageExceptions.NAME_MAXIMUM_SIZE);

            RuleFor(req => req.Email).NotEmpty().WithMessage(ResourceMessageExceptions.EMAIL_EMPTY)
                                     .MaximumLength(60).WithMessage(ResourceMessageExceptions.EMAIL_MAXIMUM_SIZE)
                                     .EmailAddress().WithMessage(ResourceMessageExceptions.EMAIL_INCORRET_FORMAT);

            RuleFor(req => req.Cnpj).NotEmpty().WithMessage(ResourceMessageExceptions.CNPJ_EMPTY)
                                    .MaximumLength(14).WithMessage(ResourceMessageExceptions.CNPJ_MAXIMUM_SIZE)
                                    .MinimumLength(14).WithMessage(ResourceMessageExceptions.CNPJ_MINIMUM_SIZE)
                                    .Matches(@"^\d+$").WithMessage(ResourceMessageExceptions.CNPJ_ONLY_NUMBERS);
        }

    }
}
