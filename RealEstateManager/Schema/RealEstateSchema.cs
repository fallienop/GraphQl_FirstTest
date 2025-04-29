namespace RealEstateManager.Schema;
using GraphQL;
using RealEstateManager.Mutations;
using RealEstateManager.Queries;

public class RealEstateSchema : GraphQL.Types.Schema
{
    public RealEstateSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<PropertyQuery>();
        Mutation = provider.GetRequiredService<PropertyMutation>();
    }
}
