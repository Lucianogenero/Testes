using System.Net;

namespace MyCompany.Exceptions.ExceptionBase
{
    public abstract class MyCompanyExceptions : SystemException
    {
        protected MyCompanyExceptions(string message) : base(message) { }

        public abstract IList<string> GetErrorMessage();
        public abstract HttpStatusCode GetStatusCode();
    }
}
