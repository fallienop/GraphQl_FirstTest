using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Utilities;
using GraphQL;
using GraphQL.Execution;
using Newtonsoft.Json.Linq;
using GraphQL.Validation;
using GraphQL.Types;
using GraphQL.SystemTextJson;
namespace RealEstateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
             
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query)); 
            }
            var queryInputs = query.ToInputs();
            Inputs inputs = new Inputs(queryInputs);

            ExecutionOptions executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Variables = inputs
            };
            var result = await _documentExecuter.ExecuteAsync(executionOptions);
            if (result.Errors.Any())
            {
                return BadRequest();
            }
            return Ok(result);
        }

        
    }
}
