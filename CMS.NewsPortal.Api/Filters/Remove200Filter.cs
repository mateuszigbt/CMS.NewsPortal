using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CMS.NewsPortal.Api.Filters
{
    public class Remove200Filter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation , OperationFilterContext context)
        {
            var path = context.ApiDescription.RelativePath?.ToLower();
            var method = context.ApiDescription.HttpMethod?.ToUpper();

            if (method == "POST" && path == "api/articles" || method == "POST" && path == "api/categories")
            {
                operation.Responses.Remove("200");
            }
        }
    }
}