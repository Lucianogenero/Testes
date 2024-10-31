using AutoMapper;
using MyCompany.Application.Extensions;
using MyCompany.Communication.Response;
using MyCompany.Domain.Repository;

namespace MyCompany.Application.UseCase.Fornecedor.ListAll
{
    public class ListFornecedor : IListFornecedor
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;

        public ListFornecedor(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<ResponseListFornecedoresJson> IListFornecedor.Execute()
        {
            var fornecedores = await _repository.ListAllFornecedor();

            return new ResponseListFornecedoresJson
            {
                fornecedores = await fornecedores.MapToResponseFornecedorJson(_mapper)
            };

        }
    }
}
