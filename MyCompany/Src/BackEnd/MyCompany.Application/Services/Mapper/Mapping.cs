using AutoMapper;
using MyCompany.Communication.Request;
using MyCompany.Communication.Response;
using MyCompany.Domain.Entities;

namespace MyCompany.Application.Services.Mapper
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            RequestToDomain();
            DomainToResponse();
        }
        private void RequestToDomain()
        {
            CreateMap<RequestFornecedorJson,Fornecedor>();
            CreateMap<RequestNewFornecedorJson,Fornecedor>();
        }

        private void DomainToResponse()
        {
            CreateMap<Fornecedor, ResponseFornecedorJson>();
            CreateMap<Fornecedor, ResponseListFornecedoresJson>();
        }
    }
}
