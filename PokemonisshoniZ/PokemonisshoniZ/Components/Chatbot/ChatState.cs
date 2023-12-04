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
using PokemonisshoniZ.Services;
using PSThonk.Share.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.WebApp.Chatbot;

public class ChatState
{

    private readonly ApplicationDbContext _context;
    private readonly PokemonisshoniService _pokemonisshoniService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ClaimsPrincipal _user;
    private readonly NavigationManager _navigationManager;
    private readonly ILogger _logger;

    private readonly OpenAIClient _aiClient;
    private readonly IKernel _ai;
    private readonly ChatHistory _chatHistory;
    private readonly ChatConfig _chatConfig;

    public ChatState(UserManager<ApplicationUser> UserManager, ClaimsPrincipal user, NavigationManager nav, ChatConfig chatConfig, ILoggerFactory loggerFactory, ApplicationDbContext context, PokemonisshoniService pokemonisshoniService)
    {
        _userManager = UserManager;
        _user = user;
        _navigationManager = nav;
        _chatConfig = chatConfig;
        _logger = loggerFactory.CreateLogger(typeof(ChatState));
        _context = context;
        _pokemonisshoniService = pokemonisshoniService;
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
            Your job is to answer customer questions about Pokemon, Pokemon match 
            Add 洛托 after each sentence.
            You try to be concise and only provide longer responses if necessary.
            If someone asks a question about anything other than Pokemon, contest, 赛, 录像, or their account,
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

        [SKFunction, Description("Find user in seasion")]
        public async Task<string> FindUserRank([Description("The id of seasion")] int seasionId, [Description("The name of find user")] string name)
        {
            try
            {
                var sessions = await chatState._pokemonisshoniService.PokemonHomeService.GetPokemonHomeSessions();
                var session = sessions.LastOrDefault(s => s.Type == PokeCommon.BattleEngine.BattleType.Double &&  s.Name.EndsWith(seasionId.ToString()));

                if (session == null)
                {
                    return "不存在此赛季";

                }
                else
                {
                    var ranks = await chatState._pokemonisshoniService.PokemonHomeService.GetHomeTrainerRankDatas(session.SeasonId);

                    var user = ranks.Where(s => s.Name.Contains(name)).Take(10);
                    return JsonSerializer.Serialize(user);
                }

            }
            catch (Grpc.Core.RpcException e) when (e.StatusCode == Grpc.Core.StatusCode.Unauthenticated)
            {
                return "Unable to add an item to the cart. You must be logged in.";
            }
            catch (Exception e)
            {
                return Error(e, "查询失败");
            }
        }
        //[SKFunction, Description("Sign up for the  contest")]
        //public string NavigateToMatchList()
        //{
        //    chatState._navigationManager.NavigateTo("match/list");
        //    return "帮你转到了比赛列表页面，请找到你想报名的比赛";
        //}

        [SKFunction, Description("Sign up for the contest")]
        public string NavigateToMatchDetail([Description("The name of contest")] string name)
        {
            var match = chatState._context.PCLMatches.OrderByDescending(s => s.Id).FirstOrDefault(c => c.Name.Contains(name));
            if (match == null)
            {
                chatState._navigationManager.NavigateTo("match/list");
                return "好像没有找到比赛，帮你转到了比赛列表页面";
            }


            chatState._navigationManager.NavigateTo($"match/detail/{match.Id}");
            return "想报名的话, 请点击下面的报名按钮";
        }

        [SKFunction, Description("Get user Replay")]
        public string GetUserPsReplay([Description("The name of user")] string name)
        {
            var username = chatState._context.PSUsername.FirstOrDefault(s => s.PSName.Contains(name));
            if (username == null)
            {
                chatState._navigationManager.NavigateTo($"/PS/MyId");

                return "你没有这个id的权限，想要观看请先绑定Id";
            }

            // todo: 权限问题记得
            chatState._navigationManager.NavigateTo($"/PS/MyId/{username.PSName}");
            // 下载插件
            return $"正在给你展示{username.PSName}的录像";
        }
        [SKFunction, Description("store pokemon team")] 
        public string StoreTeam()
        {
            chatState._navigationManager.NavigateTo($"/TeamManager");
            return "在宝可梦盒子中就可以存储队伍";

        }



        [SKFunction, Description("modify user infomation")]
        public string NavigateToUserModfiy()
        {
            chatState._navigationManager.NavigateTo("my/mymanager");
            return "这里就是你的个人信息页面";
        }


        [SKFunction, Description("Introducing website features")]
        public string Introducing()
        {
            return "这是pokemonisshoniZ网站，可以用于举办比赛，存储队伍，观看ps录像，查看排名等用途";
        }

        [SKFunction, Description("Get recent match information")]
        public string GetRecentMatch()
        {
            var items = chatState._context.PCLMatches.AsNoTracking().Take(3).ToArray();
            foreach (var item in items)
            {
                item.Description = "";
            }

            return JsonSerializer.Serialize(items);
        }

        [SKFunction, Description("Obtain user registered competitions")]
        public string GetUserMatch()
        {
            var userId = chatState._user.GetUserIdBlazor();

            var items = chatState._context.PCLMatchPlayer.AsNoTracking().Where(s => s.UserId == userId).Select(s => s.PCLMatchId).Take(3).ToArray();

            var vv = items.GetType();

            var matches = items.Select(s => chatState._context.PCLMatches.Find(s)).ToArray();
            foreach (var item in matches)
            {
                item.Description = "";
            }

            return JsonSerializer.Serialize(matches);
        }
        //[SKFunction, Description("how to use this page")]
        //public string HelpUser()
        //{
        //    var url = chatState._navigationManager.Uri;
        //    if (url.EndsWith("/TeamManager"))
        //    {
        //        return "您当前在宝可梦盒子页面, 可以右键点击宝可梦进行操作";
        //    }
        //    return "这个页面好像没有帮助信息";
        //}

        //[SKFunction, Description("Searches the Northern Mountains catalog for a provided product description")]
        //public async Task<string> SearchCatalog([Description("The product description for which to search")] string productDescription)
        //{
        //    try
        //    {
        //        return null;
        //        //var results = await chatState._catalogService.GetCatalogItemsWithSemanticRelevance(0, 8, productDescription!);
        //        //return JsonSerializer.Serialize(results);
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        return Error(e, "Error accessing catalog.");
        //    }
        //}

        //[SKFunction, Description("Adds a product to the user's shopping cart.")]
        //public async Task<string> AddToCart([Description("The id of the product to add to the shopping cart (basket)")] int itemId)
        //{
        //    try
        //    {
        //        return null;

        //        //var item = await chatState._catalogService.GetCatalogItem(itemId);
        //        //await chatState._basketState.AddAsync(item!);
        //        return "Item added to shopping cart.";
        //    }
        //    catch (Grpc.Core.RpcException e) when (e.StatusCode == Grpc.Core.StatusCode.Unauthenticated)
        //    {
        //        return "Unable to add an item to the cart. You must be logged in.";
        //    }
        //    catch (Exception e)
        //    {
        //        return Error(e, "Unable to add the item to the cart.");
        //    }
        //}

        //[SKFunction, Description("Gets information about the contents of the user's shopping cart (basket)")]
        //public async Task<string> GetCartContents()
        //{
        //    try
        //    {
        //        return null;
        //        //var basketItems = await chatState._basketState.GetBasketItemsAsync();
        //        //return JsonSerializer.Serialize(basketItems);
        //    }
        //    catch (Exception e)
        //    {
        //        return Error(e, "Unable to get the cart's contents.");
        //    }
        //}

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
