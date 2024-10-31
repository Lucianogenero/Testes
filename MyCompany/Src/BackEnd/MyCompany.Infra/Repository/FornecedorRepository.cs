using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repository;
using System.Data;


namespace MyCompany.Infra.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly string _connectionString;
        private string _query;

        public FornecedorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        async Task IFornecedorRepository.Add(Fornecedor fornecedor)
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            _query = "INSERT INTO Fornecedor (Nome,Email,Cnpj) VALUES (@Nome,@Email,@Cnpj)";

            using (var con = connection)
            {
                await con.QueryAsync(_query, new { @Nome = fornecedor.Nome, @Email = fornecedor.Email, @Cnpj = fornecedor.Cnpj });
            }
        }

        public async Task<bool> CheckCnpjAlreadyRegistered(string cnpj)
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            _query = $"SELECT CASE WHEN EXISTS(SELECT 1 FROM Fornecedor WHERE Cnpj = '{cnpj}') THEN 1 ELSE 0 END";
            
            using (var con = connection)
            {
                return await con.QuerySingleAsync<bool>(_query);
            }
        }

        async Task IFornecedorRepository.UpdateFornecedor(Fornecedor fornecedor)
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            _query = "UPDATE Fornecedor SET Ativo = @Ativo,Cnpj = @Cnpj,Nome = @Nome,Email = @Email WHERE Id = @Id";

            using (var con = connection)
            {
                await con.ExecuteAsync(_query, new {  @Ativo = fornecedor.Ativo, @Cnpj = fornecedor.Cnpj, @Nome = fornecedor.Nome, @Email = fornecedor.Email, @Id = fornecedor.Id, });
            }
        }

        async Task IFornecedorRepository.DeleteFornecedor(int id)
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            _query = $"DELETE FROM Fornecedor WHERE Id = {id}";
            var result = 0;

            using (var con = connection)
            {
               await con.ExecuteAsync(_query);
            }
        }

        async Task<Fornecedor> IFornecedorRepository.GetFornecedorId(int id)
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            _query = $"SELECT * FROM Fornecedor WHERE Id = {id}";
            using (var con = connection)
            {
                return await con.QuerySingleOrDefaultAsync<Fornecedor>(_query);
            }
        }

        async Task<List<Fornecedor>> IFornecedorRepository.ListAllFornecedor()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            _query = "SELECT * FROM Fornecedor";
            
            using (var con = connection)
            {         
                return (List<Fornecedor>)await con.QueryAsync<Fornecedor>(_query);
            }
        }

        public async Task<bool> CheckIdExistsFornecedor(int id)
        {
            if(id <= 0) return false;

            IDbConnection connection = new SqlConnection(_connectionString);
            _query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Fornecedor WHERE Id = @Id) THEN 1 ELSE 0 END";

            using (var con = connection)
            {
                return await con.QuerySingleAsync<bool>(_query,new { @id = id });
            }
        }
    }
}
