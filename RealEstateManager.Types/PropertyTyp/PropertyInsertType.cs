using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RealEstateManager.Types.PropertyTyp
{
    public class PropertyInsertType : InputObjectGraphType
    {

        public PropertyInsertType()
        {
            Name = "PropertyInsert";

            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("city");
            Field<StringGraphType>("family");
            Field<StringGraphType>("street");
            Field<NonNullGraphType<IntGraphType>>("value");
            
        }
    }
}
