namespace HortIntelligentApi.Domini.ApiKey
{
    public interface IApiKeyValidator
    {
        bool IsValid(Guid apiKey);
    }
}
