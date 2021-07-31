using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AzurLaneAPI.Filters
{
    public class RemoveSchemasDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (KeyValuePair<string, OpenApiSchema> item in swaggerDoc.Components.Schemas)
            {
                swaggerDoc.Components.Schemas.Remove(item.Key);
            }
        }
    }
}