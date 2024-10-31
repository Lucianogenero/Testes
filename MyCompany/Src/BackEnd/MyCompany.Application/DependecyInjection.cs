using Microsoft.Extensions.DependencyInjection;
using MyCompany.Application.Services.Mapper;
using MyCompany.Application.UseCase.Fornecedor.Delete;
using MyCompany.Application.UseCase.Fornecedor.GetForId;
using MyCompany.Application.UseCase.Fornecedor.ListAll;
using MyCompany.Application.UseCase.Fornecedor.Register;
using MyCompany.Application.UseCase.Fornecedor.Update;

namespace MyCompany.Application
{
    public static class DependecyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(autoMapperOptions =>
            {
                autoMapperOptions.AddProfile(new Mapping());
            }).CreateMapper());
        }

        public static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterFornecedor,RegisterFornecedor>();
            services.AddScoped<IListFornecedor,ListFornecedor>();
            services.AddScoped<IGetFornecedorId,GetFornecedorId>();
            services.AddScoped<IDeleteFornecedor,DeleteFornecedor>();
            services.AddScoped<IUpdateFornecedor,UpdateFornecedor>();
        }
    }
}
