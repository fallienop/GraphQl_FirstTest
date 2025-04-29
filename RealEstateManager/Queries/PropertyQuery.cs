using GraphQL;
using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Types.PropertyTyp;

namespace RealEstateManager.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            Field<ListGraphType<PropertyType>>("properties").Resolve(context => propertyRepository.GetAll());
            
            Field<PropertyType>("property").Argument<IntGraphType>("id").Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                return propertyRepository.GetById(id);
            });
        }
    }
}
