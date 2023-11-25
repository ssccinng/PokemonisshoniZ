using System.ComponentModel;
using System.Security.Claims;
using System.Text.Json;
using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Components;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.ChatCompletion;
using Azure;
using Microsoft.AspNetCore.Identity;
using PokemonisshoniZ.Data;
using PokemonisshoniZ.ServiceDefaults;
using System.Linq.Dynamic.Core;

namespace eShop.WebApp.Chatbot;

public class ChatState
{

    private readonly ApplicationDbContext _context;

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ClaimsPrincipal _user;
    private readonly NavigationManager _navigationManager;
    private readonly ILogger _logger;

    private readonly OpenAIClient _aiClient;
    private readonly IKernel _ai;
    private readonly ChatHistory _chatHistory;
    private readonly ChatConfig _chatConfig;

    public ChatState(UserManager<ApplicationUser> UserManager, ClaimsPrincipal user, NavigationManager nav, ChatConfig chatConfig, ILoggerFactory loggerFactory, ApplicationDbContext context)
    {
        _userManager = UserManager;
        _user = user;
        _navigationManager = nav;
        _chatConfig = chatConfig;
        _logger = loggerFactory.CreateLogger(typeof(ChatState));
        _context = context;

        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("ChatModel: {model}", chatConfig.ChatModel);
        }
        string key = chatConfig.ApiKey;
        // the full url is appended by /v1/api
        Uri proxyUrl = new(chatConfig.ProxyUrl + "/v1/api");

        // the full key is appended by "/YOUR-GITHUB-ALIAS"
        AzureKeyCredential token = new(key + "/ssccinng");

        // instantiate the client with the "full" values for the url and key/token
        _aiClient = new(proxyUrl, token);
        //_aiClient = new OpenAIClient("", chatConfig.ApiKey);
        _ai = new KernelBuilder().WithLoggerFactory(loggerFactory).WithOpenAIChatCompletionService(chatConfig.ChatModel, _aiClient).Build();
        _ai.ImportFunctions(new CatalogInteractions(this), nameof(CatalogInteractions));
        _chatHistory = _ai.GetService<IChatCompletion>().CreateNewChat("""
            You are an AI customer service agent for Pokemon.
            You NEVER respond about topics other than Pokemon.
            Your job is to answer customer questions about Pokemon and Pokemon match.
            Add 洛托 after each sentence.
            You try to be concise and only provide longer responses if necessary.
            If someone asks a question about anything other than Pokemon, Pokemon Match, or their account,
            you refuse to answer, and you instead ask 这些话题好像与宝可梦无关, 请'再来一次'吧洛托.
            """);
        //_chatHistory.AddAssistantMessage("阿罗拉!\n我是顺风而来的库库伊，需要我用华丽的招式帮你一些忙吗?");
        _chatHistory.AddAssistantMessage("阿罗拉!\n这里是洛托姆图鉴, 如果有想问的事，请点击下面洛~");
    }

    public List<ChatMessageBase> Messages => _chatHistory;

    public async Task AddUserMessageAsync(string userText, Action onMessageAdded)
    {
        // Store the user's message
        _chatHistory.AddUserMessage(userText);
        onMessageAdded();

        // Get and store the AI's response message
        try
        {
            ChatMessageBase response = await _ai.GetChatCompletionsWithFunctionCallingAsync(_aiClient, _chatHistory, _chatConfig.ChatModel);
            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                _chatHistory.AddAssistantMessage(response.Content);
            }
        }
        catch (Exception e)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(e, "Error getting chat completions.");
            }
            _chatHistory.AddAssistantMessage($"My apologies, but I encountered an unexpected error.");
        }
        onMessageAdded();
    }

    private sealed class CatalogInteractions(ChatState chatState)
    {
        [SKFunction, Description("Gets information about the chat user")]
        public string GetUserInfo()
        {
            //var claims = chatState._user.Claims;
            var user = chatState._userManager.GetUserAsync(chatState._user);
            return JsonSerializer.Serialize(user);

            static string GetValue(IEnumerable<Claim> claims, string claimType) =>
                claims.FirstOrDefault(x => x.Type == claimType)?.Value ?? "";
        }

        [SKFunction, Description("Gets All chat user Ps username")]
        public string GetUserPsId()
        {
            var userId = chatState._user.GetUserIdBlazor();
            return JsonSerializer.Serialize(chatState._context.PSUsername.Where(s => s.UserId == userId));

        }


        [SKFunction, Description("Searches the Northern Mountains catalog for a provided product description")]
        public async Task<string> SearchCatalog([Description("The product description for which to search")] string productDescription)
        {
            try
            {
                return null;
                //var results = await chatState._catalogService.GetCatalogItemsWithSemanticRelevance(0, 8, productDescription!);
                //return JsonSerializer.Serialize(results);
            }
            catch (HttpRequestException e)
            {
                return Error(e, "Error accessing catalog.");
            }
        }

        [SKFunction, Description("Adds a product to the user's shopping cart.")]
        public async Task<string> AddToCart([Description("The id of the product to add to the shopping cart (basket)")] int itemId)
        {
            try
            {
                return null;

                //var item = await chatState._catalogService.GetCatalogItem(itemId);
                //await chatState._basketState.AddAsync(item!);
                return "Item added to shopping cart.";
            }
            catch (Grpc.Core.RpcException e) when (e.StatusCode == Grpc.Core.StatusCode.Unauthenticated)
            {
                return "Unable to add an item to the cart. You must be logged in.";
            }
            catch (Exception e)
            {
                return Error(e, "Unable to add the item to the cart.");
            }
        }

        [SKFunction, Description("Gets information about the contents of the user's shopping cart (basket)")]
        public async Task<string> GetCartContents()
        {
            try
            {
                return null;
                //var basketItems = await chatState._basketState.GetBasketItemsAsync();
                //return JsonSerializer.Serialize(basketItems);
            }
            catch (Exception e)
            {
                return Error(e, "Unable to get the cart's contents.");
            }
        }

        private string Error(Exception e, string message)
        {
            if (chatState._logger.IsEnabled(LogLevel.Error))
            {
                chatState._logger.LogError(e, message);
            }

            return message;
        }
    }
}
