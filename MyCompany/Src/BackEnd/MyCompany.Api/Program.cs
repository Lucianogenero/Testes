using MyCompany.Api.Filters;
using MyCompany.Application;
using MyCompany.Infra;
using MyCompany.Infra.Migrations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Exceptions
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFiltersClass)));

// addDependenciInjection
builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Luciano",
            Email = "luciano.generolg@gmail.com"
        }
    });

    var xmlFile = "MyCompany.Api.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Migrate();

app.Run();

void Migrate()
{
    var connectioString = builder.Configuration.GetConnectionString("DefaultConnection")?.ToString();
    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    DataBaseMigrations.Migrate(connectioString, serviceScope.ServiceProvider);
}