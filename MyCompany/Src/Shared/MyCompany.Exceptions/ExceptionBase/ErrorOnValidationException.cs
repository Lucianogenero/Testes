using System.Net;

namespace MyCompany.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : MyCompanyExceptions
    {
        private readonly IList<string> _errorMessage;

        public ErrorOnValidationException(IList<string> errorMessage) : base(string.Empty)
        {
            this._errorMessage = errorMessage;
        }

        public override IList<string> GetErrorMessage() => _errorMessage;

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
