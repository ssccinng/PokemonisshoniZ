using System.Diagnostics.CodeAnalysis;

namespace eShop.WebApp.Chatbot;

public record ChatConfig(string ApiKey, string ChatModel, string ProxyUrl)
{
    public static bool TryReadFromConfig(IConfiguration configuration, [NotNullWhen(true)] out ChatConfig? result)
    {
        var apiKey = configuration["AI:OpenAI:APIKey"];
        var chatModel = configuration["AI:OpenAI:ChatName"] ?? "gpt-3.5-turbo-16k";
        var proxyUrl = configuration["AI:OpenAI:ProxyUrl"];
        result = (!string.IsNullOrWhiteSpace(apiKey) && !string.IsNullOrWhiteSpace(proxyUrl)) ? new ChatConfig(apiKey, chatModel, proxyUrl) : null;
        return result is not null;
    }
}
