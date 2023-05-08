using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HortIntelligentApi.Domini.ApiKey
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        private const string ApiKeyHeaderName = "X-API-KEY-ARDUINO";

        private readonly IApiKeyValidator _apiKeyValidator;

        public ApiKeyAuthorizationFilter(IApiKeyValidator apiKeyValidator)
        {
            _apiKeyValidator = apiKeyValidator;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];
            Guid keyGuid;
            if (!Guid.TryParse(apiKey, out keyGuid))
                context.Result = new UnauthorizedResult();
            else
            {
                if (!_apiKeyValidator.IsValid(keyGuid))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
