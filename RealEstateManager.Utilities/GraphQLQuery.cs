using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RealEstateManager.Utilities
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query {  get; set; }
        public JObject Variables { get; set; }


        public Dictionary<string, object> ToInputs()
        {
            var inputs = Variables.ToObject<Dictionary<string, object>>();
            return inputs;
        }
    }
}
