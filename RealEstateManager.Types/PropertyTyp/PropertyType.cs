using GraphQL;
using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database.Models;
using RealEstateManager.Types.PaymentTyp;

namespace RealEstateManager.Types.PropertyTyp
{
    public class PropertyType : ObjectGraphType<Property>
    {
        public PropertyType(IPaymentRepository paymentRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Family);
            Field(x => x.Street);

            Field<ListGraphType<PaymentType>>("payments")
           .Argument<IntGraphType>("last")
           .Resolve(context =>
           {
               var lastPaymentsFilter = context.GetArgument<int?>("last");
               return lastPaymentsFilter is null
                   ? paymentRepository.GetAll(context.Source.Id)
                   : paymentRepository.GetLastWithCount(context.Source.Id, lastPaymentsFilter.Value);
           });


        }
    }
}
