using GraphQL;
using GraphQL.Server;                     
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.DataAccess.Repositories.Services;
using RealEstateManager.Database.Context;
using RealEstateManager.Mutations;
using RealEstateManager.Queries;
using RealEstateManager.Schema;
using RealEstateManager.Types.PaymentTyp;
using RealEstateManager.Types.PropertyTyp;
using ServiceLifetime = GraphQL.DI.ServiceLifetime;
using GraphQL.Execution;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddSqlServer<RealEstateContext>(builder.Configuration.GetConnectionString("RealEstateGraph"));

//builder.Services.AddScoped<IDocumentExecuter,DocumentExecuter>();
//builder.Services.AddSingleton(typeof(IDocumentExecuter<>), typeof(DocumentExecuter<>));
builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

builder.Services.AddScoped<PropertyQuery>();
builder.Services.AddScoped<PropertyMutation>();

builder.Services.AddScoped<PropertyType>();
builder.Services.AddScoped<PropertyInsertType>();
builder.Services.AddScoped<PaymentType>();


builder.Services.AddGraphQL(b=>b.AddSystemTextJson().AddGraphTypes().AddClrTypeMappings().AddSchema<RealEstateSchema>(serviceLifetime: ServiceLifetime.Scoped).AddExecutionStrategy<SerialExecutionStrategy>(GraphQLParser.AST.OperationType.Query));

//builder.Services.AddGraphQL(b => b.AddSystemTextJson().AddSchema<RealEstateSchema>(serviceLifetime: ServiceLifetime.Scoped));
var app = builder.Build();

app.UseGraphQL();
app.UseGraphQLAltair();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.MapControllers();

app.Run();
