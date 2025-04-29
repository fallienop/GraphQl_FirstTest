using GraphQL;
using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database.Models;
using RealEstateManager.Types.PropertyTyp;

namespace RealEstateManager.Mutations
{
    public class PropertyMutation : ObjectGraphType
    {
        public PropertyMutation(IPropertyRepository propertyRepository)
        {
            Name = "AddPropertyMutation";

            Field<PropertyType>("addProperty").Argument<NonNullGraphType<PropertyInsertType>>("property").Resolve(context =>
            {
                var newProperty = context.GetArgument<Property>("property");
                var insertedProperty = propertyRepository.AddProperty(newProperty);
                return insertedProperty;
            });
        }
    }
}
