using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Domini.ApiKey
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
