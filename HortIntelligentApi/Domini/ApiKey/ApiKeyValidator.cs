using HortIntelligent.Dades.EntityFramework;

namespace HortIntelligentApi.Domini.ApiKey
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        private readonly HortIntelligentDbContext context;

        public ApiKeyValidator(HortIntelligentDbContext context)
        {
            this.context = context;
        }
        public bool IsValid(Guid apiKey)
        {
            var apiKeys = context.ApiKeys.ToList();
            var key = apiKeys.Where(w => w.Key == apiKey && w.Exipres > DateTime.Now).FirstOrDefault();
            if (key != null)
                return true;
            else 
                return false;
        }
    }
}
