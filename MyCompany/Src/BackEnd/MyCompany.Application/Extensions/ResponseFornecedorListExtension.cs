using AutoMapper;
using MyCompany.Communication.Response;
using MyCompany.Domain.Entities;

namespace MyCompany.Application.Extensions
{
    public static class ResponseFornecedorListExtension
    {
        public static async Task<IList<ResponseFornecedorJson>> MapToResponseFornecedorJson(this IList<Fornecedor> fornecedores, IMapper mapper)
        {
            var result = fornecedores.Select(async fornecedor =>
            {
                var response = mapper.Map<ResponseFornecedorJson>(fornecedor);
                return response;
            });

            return await Task.WhenAll(result);

        }

    }
}
