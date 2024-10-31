using FluentMigrator;

namespace MyCompany.Infra.Migrations.DataBaseVersion
{
    [Migration(DataBaseVersions.TABLE_FORNECEDOR,"Create table Fornecedor")]
    public class Migrator0000001 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Fornecedor")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Ativo").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("Nome").AsString(60).NotNullable()
                .WithColumn("Email").AsString(60).NotNullable()
                .WithColumn("Cnpj").AsString(14).NotNullable();   
            
        }
    }
}
