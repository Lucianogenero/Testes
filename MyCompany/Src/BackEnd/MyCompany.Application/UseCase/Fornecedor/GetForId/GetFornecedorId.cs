using AutoMapper;
using MyCompany.Communication.Response;
using MyCompany.Domain.Repository;

namespace MyCompany.Application.UseCase.Fornecedor.GetForId
{
    public class GetFornecedorId : IGetFornecedorId
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;
        public GetFornecedorId(IFornecedorRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ResponseFornecedorJson> Execute(int id)
        {
            var response = await _repository.GetFornecedorId(id);
            var result = _mapper.Map<ResponseFornecedorJson>(response);
            return result;
        }
    }
}
